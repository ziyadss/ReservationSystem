using ReservationSystem.Data.Users;
using System;

namespace ReservationSystem.DataStructures.Users;

/// <summary>
/// The payload to edit a user.
/// </summary>
public class EditUserPayload
{
    /// <summary>
    /// The user's first name.
    /// </summary>
    public required string FirstName { get; set; }

    /// <summary>
    /// The user's last name.
    /// </summary>
    public required string LastName { get; set; }

    /// <summary>
    /// The user's birthdate.
    /// </summary>
    public required DateTime Birthdate { get; set; }

    /// <summary>
    /// The user's gender.
    /// </summary>
    public required Gender Gender { get; set; }

    /// <summary>
    /// The user's nationality.
    /// </summary>
    public string? Nationality { get; set; }
}
