using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ReservationSystem.Data.Users;
using ReservationSystem.DataStructures.Authentication;
using ReservationSystem.DataStructures.Users;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

/// <summary>
/// Provides methods for user registration, login, and password change.
/// </summary>
[ApiController]
[Route("api/auth")]
public class AuthorizationController : BaseController<AuthorizationController>
{
    private readonly UserManager<User> _userManager;
    private readonly JwtSecurityTokenHandler _jwtSecurityTokenHandler;
    private readonly JwtTokenSettings _jwtBearerTokenSettings;

    /// <summary>
    /// Creates a new instance of the <see cref="AuthorizationController"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    /// <param name="userManager">The user manager.</param>
    /// <param name="jwtBearerTokenSettings">The JWT bearer token settings.</param>
    public AuthorizationController(
        ILogger<AuthorizationController> logger,
        UserManager<User> userManager,
        JwtTokenSettings jwtBearerTokenSettings) : base(logger)
    {
        _userManager = userManager;
        _jwtBearerTokenSettings = jwtBearerTokenSettings;
        _jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
    }

    /// <summary>
    /// Registers a new user.
    /// </summary>
    /// <param name="newUserPayload">The payload of the new user.</param>
    /// <response code="200">Returns an authentication result.</response>
    /// <response code="400">If the payload is null or the user could not be registered for some reason.</response>
    [HttpPost("register")]
    [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Register([FromBody] NewUserPayload newUserPayload)
    {
        _logger.LogInformation($"Call to {nameof(AuthorizationController)}.{nameof(Register)}");

        if (newUserPayload is null)
        {
            return NullParameter(nameof(newUserPayload));
        }

        var user = new User(
            newUserPayload.UserName,
            newUserPayload.Email,
            newUserPayload.FirstName,
            newUserPayload.LastName,
            newUserPayload.Birthdate,
            newUserPayload.Gender,
            newUserPayload.Nationality);

        var identityResult = await _userManager.CreateAsync(user, newUserPayload.Password).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            return BadRequest(identityResult);
        }

        identityResult = await _userManager.AddToRoleAsync(user, "User").ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to set role for user {userName}", user.UserName);

            var innerIdentityResult = await _userManager.DeleteAsync(user).ConfigureAwait(false);
            if (!innerIdentityResult.Succeeded)
            {
                _logger.LogError("Failed to delete user {userName} after failed role assignment, result: {result}", user.UserName, innerIdentityResult);
            }
            else
            {
                _logger.LogInformation("Deleted user {userName} after failed role assignment", user.UserName);
            }

            return InternalServerError("Failed to set role for user. User creation aborted.");
        }

        var result = await GetAuthenticationResult(user).ConfigureAwait(false);

        return Ok(result);
    }

    /// <summary>
    /// Gets the authentication result for a user.
    /// </summary>
    /// <param name="authenticationPayload">The authentication payload of the user.</param>
    /// <response code="200">Returns an authentication result.</response>
    /// <response code="400">If the authentication payload is null.</response>
    /// <response code="401">If the username or password is incorrect.</response>
    [HttpPost("login")]
    [ProducesResponseType(typeof(AuthenticationResult), StatusCodes.Status200OK)]
    public async Task<IActionResult> Login([FromBody] AuthenticationPayload authenticationPayload)
    {
        _logger.LogInformation($"Call to {nameof(AuthorizationController)}.{nameof(Login)}");

        if (authenticationPayload is null)
        {
            return NullParameter(nameof(authenticationPayload));
        }

        if (string.IsNullOrWhiteSpace(authenticationPayload.UserName))
        {
            return NullParameter(nameof(authenticationPayload.UserName));
        }

        var user = await _userManager.FindByNameAsync(authenticationPayload.UserName).ConfigureAwait(false);
        if (user is null)
        {
            return Unauthorized("Invalid username.");
        }

        var correctPassword = await _userManager.CheckPasswordAsync(user, authenticationPayload.Password).ConfigureAwait(false);
        if (!correctPassword)
        {
            return Unauthorized("Incorrect password.");
        }

        var result = await GetAuthenticationResult(user).ConfigureAwait(false);

        return Ok(result);
    }

    /// <summary>
    /// Changes the password of the current user.
    /// </summary>
    /// <param name="changePasswordPayload">The payload of the password change.</param>
    /// <response code="204">Successfully changed password.</response>
    /// <response code="400">If the change password payload is null or the new password is null or empty, or failed to change password for another reason.</response>
    [Authorize]
    [HttpPost("password")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordPayload changePasswordPayload)
    {
        _logger.LogInformation($"Call to {nameof(AuthorizationController)}.{nameof(ChangePassword)}");

        if (changePasswordPayload is null)
        {
            return NullParameter(nameof(changePasswordPayload));
        }

        if (string.IsNullOrWhiteSpace(changePasswordPayload.NewPassword))
        {
            return NullParameter(nameof(changePasswordPayload.NewPassword));
        }

        var userName = User.Identity!.Name!;
        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        if (user is null)
        {
            _logger.LogError("Failed to find user {userName} who is authenticated", userName);
            return InternalServerError($"Failed to find user {userName} who is authenticated.");
        }

        var identityResult = await _userManager.ChangePasswordAsync(user, changePasswordPayload.OldPassword, changePasswordPayload.NewPassword).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to change password for user {userName}", user.UserName);
            return BadRequest(identityResult);
        }

        return NoContent();
    }

    private async Task<AuthenticationResult> GetAuthenticationResult(User user)
    {
        var role = (await _userManager.GetRolesAsync(user).ConfigureAwait(false)).Single();
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName!),
            new Claim(ClaimTypes.Role, role)
        };

        var expiry = DateTime.Now.AddSeconds(_jwtBearerTokenSettings.ExpiryTimeInSeconds);
        var symmetricSecurityKey = new SymmetricSecurityKey(_jwtBearerTokenSettings.KeyBytes);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = expiry,
            SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature),
            Audience = _jwtBearerTokenSettings.Audience,
            Issuer = _jwtBearerTokenSettings.Issuer
        };

        var securityToken = _jwtSecurityTokenHandler.CreateToken(tokenDescriptor);
        var tokenString = _jwtSecurityTokenHandler.WriteToken(securityToken);

        return new AuthenticationResult
        {
            UserName = user.UserName!,
            Token = tokenString,
            Expiry = expiry,
            Role = role
        };
    }
}
