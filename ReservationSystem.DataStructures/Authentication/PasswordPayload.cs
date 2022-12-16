namespace ReservationSystem.DataStructures.Authentication;

/// <summary>
/// The payload for authentication.
/// </summary>
public class ChangePasswordPayload
{
    /// <summary>
    /// The old password.
    /// </summary>
    public required string OldPassword { get; set; }

    /// <summary>
    /// The new password.
    /// </summary>
    public required string NewPassword { get; set; }
}
