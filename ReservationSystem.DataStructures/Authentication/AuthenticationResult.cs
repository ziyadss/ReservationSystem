using System;

namespace ReservationSystem.DataStructures.Authentication;

/// <summary>
/// The result of an authentication.
/// </summary>
public class AuthenticationResult
{
    /// <summary>
    /// The user name.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// The token.
    /// </summary>
    public required string Token { get; set; }

    /// <summary>
    /// The token expiry date and time.
    /// </summary>
    public required DateTime Expiry { get; set; }

    /// <summary>
    /// The user's role.
    /// </summary>
    public required string Role { get; set; }
}
