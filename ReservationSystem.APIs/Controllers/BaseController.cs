using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;

namespace ReservationSystem.APIs.Controllers;

public class BaseController<TController> : ControllerBase
    where TController : BaseController<TController>
{
    protected readonly ILogger<TController> _logger;

    private const string InvalidParameterErrorKey = "InvalidParameter";
    private const string AuthorizationErrorKey = "Authorization";
    private const string InternalServerErrorKey = "InternalServerError";

    public BaseController(ILogger<TController> logger)
    {
        _logger = logger;
    }

    [NonAction]
    public virtual BadRequestObjectResult NullParameter(string parameterName)
    {
        if (string.IsNullOrWhiteSpace(parameterName))
        {
            throw new ArgumentException("Parameter name cannot be null or empty.", nameof(parameterName));
        }

        var message = $"Parameter {parameterName} cannot be null or empty.";
        return InvalidParameter(message);
    }

    [NonAction]
    public virtual BadRequestObjectResult InvalidParameter(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        return BadRequest(InvalidParameterErrorKey, message);
    }

    [NonAction]
    public virtual BadRequestObjectResult BadRequest(string key, string message)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        var errors = SingletonErrorDictionary(key, message);

        return BadRequest(errors);
    }

    [NonAction]
    public virtual BadRequestObjectResult BadRequest(IdentityResult result)
    {
        if (result is null)
        {
            throw new ArgumentNullException(nameof(result));
        }

        if (result.Succeeded)
        {
            throw new ArgumentException("Identity result in BadRequest cannot be successful.", nameof(result));
        }

        var errors = new ModelStateDictionary();
        foreach (var error in result.Errors)
        {
            errors.AddModelError(error.Code, error.Description);
        }

        return BadRequest(errors);
    }

    [NonAction]
    public virtual UnauthorizedObjectResult Unauthorized(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        var errors = SingletonErrorDictionary(AuthorizationErrorKey, message);

        return Unauthorized(errors);
    }

    [NonAction]
    public virtual ObjectResult InternalServerError(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        var suffixedMessage = $"{message} Please contact the site administrator.";
        var errors = SingletonErrorDictionary(InternalServerErrorKey, suffixedMessage);

        return StatusCode(StatusCodes.Status500InternalServerError, errors);
    }

    private static ModelStateDictionary SingletonErrorDictionary(string key, string message)
    {
        var errors = new ModelStateDictionary();
        errors.AddModelError(key, message);
        return errors;
    }
}
