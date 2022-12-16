namespace ReservationSystem.DataStructures.Users;

/// <summary>
/// The payload for an update role request.
/// </summary>
public class UpdateRolePayload
{
    /// <summary>
    /// The user's new role.
    /// </summary>
    public required string Role { get; set; }
}
