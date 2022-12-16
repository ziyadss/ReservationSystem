using ReservationSystem.Data.Users;
using System;

namespace ReservationSystem.DataStructures.Users;

/// <summary>
/// Information about a user.
/// </summary>
public class UserInfo
{
    /// <summary>
    /// The user's username.
    /// </summary>
    public string UserName { get; set; }

    /// <summary>
    /// The user's first name.
    /// </summary>
    public string FirstName { get; set; }

    /// <summary>
    /// The user's last name.
    /// </summary>
    public string LastName { get; set; }

    /// <summary>
    /// The user's email.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    /// The user's birthdate.
    /// </summary>
    public DateTime Birthdate { get; set; }

    /// <summary>
    /// The user's gender.
    /// </summary>
    public Gender Gender { get; set; }

    /// <summary>
    /// The user's nationality.
    /// </summary>
    public string? Nationality { get; set; }

    /// <summary>
    /// The user's role.
    /// </summary>
    public string Role { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="UserInfo"/>.
    /// </summary>
    /// <param name="user">The user.</param>
    /// <param name="role">The user's role.</param>
    public UserInfo(User user, string role)
    {
        if (user is null)
        {
            throw new ArgumentNullException(nameof(user));
        }

        if (string.IsNullOrWhiteSpace(role))
        {
            throw new ArgumentException($"'{nameof(role)}' cannot be null or whitespace.", nameof(role));
        }

        UserName = user.UserName!;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Email = user.Email!;
        Birthdate = user.Birthdate;
        Gender = user.Gender;
        Nationality = user.Nationality;
        Role = role;
    }
}
