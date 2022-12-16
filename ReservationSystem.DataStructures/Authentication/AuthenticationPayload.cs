namespace ReservationSystem.DataStructures.Authentication;

/// <summary>
/// The payload for authentication.
/// </summary>
public class AuthenticationPayload
{
    /// <summary>
    /// The user name.
    /// </summary>
    public required string UserName { get; set; }

    /// <summary>
    /// The password.
    /// </summary>
    public required string Password { get; set; }
}
