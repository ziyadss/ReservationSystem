using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ReservationSystem.Data.Users;
using ReservationSystem.DataStructures;
using ReservationSystem.DataStructures.Users;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.APIs.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : BaseController<UsersController>
{
    private readonly UserManager<User> _userManager;

    public UsersController(ILogger<UsersController> logger, UserManager<User> userManager) : base(logger)
    {
        _userManager = userManager;
    }

    /// <summary>
    /// Gets a list of users.
    /// </summary>
    /// <param name="skip">The index of the first user to return.</param>
    /// <param name="take">The maximum number of users to return.</param>
    /// <response code="200">Returns a <see cref="PaginationResult{TElement}"/> of <see cref="UserInfo"/> items.</response>
    [HttpGet]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(typeof(PaginationResult<UserInfo>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUsers([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        _logger.LogInformation($"Call to {nameof(UsersController)}.{nameof(GetUsers)}");

        var users = await _userManager.Users.Skip(skip).Take(take).ToListAsync().ConfigureAwait(false);

        var userInfos = new List<UserInfo>();
        foreach (var user in users)
        {
            var role = (await _userManager.GetRolesAsync(user).ConfigureAwait(false)).Single();
            var userInfo = new UserInfo(user, role);
            userInfos.Add(userInfo);
        }

        var count = await _userManager.Users.CountAsync().ConfigureAwait(false);

        var done = skip + take >= count;
        var next = done ? null : Url.ActionLink(values: new { skip = skip + take, take });

        var result = new PaginationResult<UserInfo>
        {
            Items = userInfos,
            Skip = skip,
            Take = take,
            Total = count,
            Next = next
        };

        return Ok(result);
    }

    /// <summary>
    /// Removes a user.
    /// </summary>
    /// <param name="userName">The user name.</param>
    /// <response code="204">The user was removed.</response>
    /// <response code="400">The user name sent is null or empty, or failed to remove user for another reason.</response>
    /// <response code="404">The user was not found.</response>
    [HttpDelete("{userName}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> RemoveUser([FromRoute] string userName)
    {
        _logger.LogInformation($"Call to {nameof(UsersController)}.{nameof(RemoveUser)}");

        if (string.IsNullOrWhiteSpace(userName))
        {
            return NullParameter(nameof(userName));
        }

        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        if (user is null)
        {
            return NotFound();
        }

        var identityResult = await _userManager.DeleteAsync(user).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to remove user {userName}", user.UserName);
            return BadRequest(identityResult);
        }

        return NoContent();
    }

    /// <summary>
    /// Updates a user's role.
    /// </summary>
    /// <param name="userName">The user name.</param>
    /// <param name="role">The role.</param>
    /// <response code="204">The user's role was updated or did not need to be updated.</response>
    /// <response code="400">The user name or role sent is null or empty, or failed to update user's role for another reason.</response>
    /// <response code="404">The user was not found.</response>
    [HttpPatch("{userName}")]
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> UpdateRole([FromRoute] string userName, [FromBody] UpdateRolePayload updateRolePayload)
    {
        _logger.LogInformation($"Call to {nameof(UsersController)}.{nameof(UpdateRole)}");

        if (string.IsNullOrWhiteSpace(userName))
        {
            return NullParameter(nameof(userName));
        }

        if (updateRolePayload is null)
        {
            return NullParameter(nameof(updateRolePayload));
        }

        if (string.IsNullOrWhiteSpace(updateRolePayload.Role))
        {
            return NullParameter(nameof(updateRolePayload.Role));
        }

        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        if (user is null)
        {
            return NotFound();
        }

        var currentRole = (await _userManager.GetRolesAsync(user).ConfigureAwait(false)).Single();
        if (currentRole == updateRolePayload.Role)
        {
            return NoContent();
        }

        var identityResult = await _userManager.RemoveFromRoleAsync(user, currentRole).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to remove user {userName} from role {role}, result: {result}", user.UserName, currentRole, identityResult);
            return BadRequest(identityResult);
        }

        identityResult = await _userManager.AddToRoleAsync(user, updateRolePayload.Role).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to add user {userName} to role {role}, result: {identityResult}", user.UserName, updateRolePayload.Role, identityResult);

            var innerIdentityResult = await _userManager.AddToRoleAsync(user, currentRole).ConfigureAwait(false);
            if (!innerIdentityResult.Succeeded)
            {
                _logger.LogError("Failed to add backk user {userName} to role {role}, result: {identityResult}", user.UserName, currentRole, innerIdentityResult);
            }
            else
            {
                _logger.LogInformation("Added back user {userName} to role {role}", user.UserName, currentRole);
            }

            return InternalServerError("Failed to set role for user. User creation aborted.");
        }

        return NoContent();
    }

    /// <summary>
    /// Gets the current user.
    /// </summary>
    /// <response code="200">Return a <see cref="UserInfo"/> object for the currently logged in user.</response>
    [HttpGet("me")]
    [Authorize]
    [ProducesResponseType(typeof(UserInfo), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetCurrentUser()
    {
        _logger.LogInformation($"Call to {nameof(UsersController)}.{nameof(GetCurrentUser)}");

        var userName = User.Identity!.Name!;
        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        if (user is null)
        {
            _logger.LogError("Failed to find user {userName} who is authenticated", userName);
            return InternalServerError($"Failed to find user {userName} who is authenticated.");
        }

        var role = (await _userManager.GetRolesAsync(user).ConfigureAwait(false)).Single();

        var userInfo = new UserInfo(user, role);
        return Ok(userInfo);
    }

    /// <summary>
    /// Edits the current user.
    /// </summary>
    /// <param name="editUserPayload">The edit user payload.</param>
    /// <response code="204">The user was edited.</response>
    /// <response code="400">The edit user payload sent is null, or failed to edit user for another reason.</response>
    [HttpPatch("me")]
    [Authorize]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> EditCurrentUser([FromBody] EditUserPayload editUserPayload)
    {
        _logger.LogInformation($"Call to {nameof(UsersController)}.{nameof(EditCurrentUser)}");

        var userName = User.Identity!.Name!;
        var user = await _userManager.FindByNameAsync(userName).ConfigureAwait(false);
        if (user is null)
        {
            _logger.LogError("Failed to find user {userName} who is authenticated", userName);
            return InternalServerError($"Failed to find user {userName} who is authenticated.");
        }

        user.FirstName = editUserPayload.FirstName;
        user.LastName = editUserPayload.LastName;
        user.Birthdate = editUserPayload.Birthdate;
        user.Gender = editUserPayload.Gender;
        user.Nationality = editUserPayload.Nationality;

        var identityResult = await _userManager.UpdateAsync(user).ConfigureAwait(false);
        if (!identityResult.Succeeded)
        {
            _logger.LogError("Failed to edit user {userName} using {payload}", user.UserName, editUserPayload);
            return BadRequest(identityResult);
        }

        return NoContent();
    }
}
