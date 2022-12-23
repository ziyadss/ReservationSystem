using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using System;

namespace ReservationSystem.APIs.Controllers;

/// <summary>
/// Base class for controllers.
/// </summary>
/// <typeparam name="TController">The type of the controller.</typeparam>
public class BaseController<TController> : ControllerBase
    where TController : BaseController<TController>
{
    /// <summary>
    /// The logger.
    /// </summary>
    protected readonly ILogger<TController> _logger;

    private const string InvalidParameterErrorKey = "InvalidParameter";
    private const string AuthorizationErrorKey = "Authorization";
    private const string InternalServerErrorKey = "InternalServerError";

    /// <summary>
    /// Initializes a new instance of the <see cref="BaseController{TController}"/> class.
    /// </summary>
    /// <param name="logger">The logger.</param>
    public BaseController(ILogger<TController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Returns a bad request result with a single error for a null or empty parameter.
    /// </summary>
    /// <param name="parameterName">The name of the parameter that caused the error.</param>
    /// <returns>The bad request result.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="parameterName"/> is null or empty.
    /// </exception>
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

    /// <summary>
    /// Returns a bad request result with a single error for an invalid paraemeter, with the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>The bad request result.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="message"/> is null or empty.
    /// </exception>
    [NonAction]
    public virtual BadRequestObjectResult InvalidParameter(string message)
    {
        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        return BadRequest(InvalidParameterErrorKey, message);
    }

    /// <summary>
    /// Returns a bad request result with a single error containing the specified message.
    /// </summary>
    /// <param name="key">The error key.</param>
    /// <param name="message">The error message.</param>
    /// <returns>The bad request result.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="key"/> is null or empty.
    /// Thrown if <paramref name="message"/> is null or empty.
    /// </exception>
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

    /// <summary>
    /// Returns a bad request result based on the specified identity result.
    /// </summary>
    /// <param name="result">The identity result.</param>
    /// <returns>The bad request result.</returns>
    /// <exception cref="ArgumentNullException">
    /// Thrown if <paramref name="result"/> is null.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="result"/> is successful.
    /// </exception>
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

    /// <summary>
    /// Returns an unauthorized result with a single error containing the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>The unauthorized result.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="message"/> is null or empty.
    /// </exception>
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

    /// <summary>
    /// Returns an internal server error result with a single error containing the specified message.
    /// </summary>
    /// <param name="message">The error message.</param>
    /// <returns>The internal server error result.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="message"/> is null or empty.
    /// </exception>
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

    /// <summary>
    /// Creates a model state dictionary with a single error.
    /// </summary>
    /// <param name="key">The error key.</param>
    /// <param name="message">The error message.</param>
    /// <returns>The model state dictionary.</returns>
    /// <exception cref="ArgumentException">
    /// Thrown if <paramref name="key"/> is null or empty.
    /// Thrown if <paramref name="message"/> is null or empty.
    /// </exception>
    private static ModelStateDictionary SingletonErrorDictionary(string key, string message)
    {
        if (string.IsNullOrWhiteSpace(key))
        {
            throw new ArgumentException("Key cannot be null or empty.", nameof(key));
        }

        if (string.IsNullOrWhiteSpace(message))
        {
            throw new ArgumentException("Message cannot be null or empty.", nameof(message));
        }

        var errors = new ModelStateDictionary();
        errors.AddModelError(key, message);
        return errors;
    }
}
