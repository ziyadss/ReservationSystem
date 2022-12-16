using Microsoft.AspNetCore.Identity;
using ReservationSystem.Data.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Data.Users;

public class User : IdentityUser
{
    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string FirstName { get; set; }

    [Required]
    [StringLength(20, MinimumLength = 3)]
    public string LastName { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateTime Birthdate { get; set; }

    [Required]
    [EnumDataType(typeof(Gender))]
    public Gender Gender { get; set; }

    [StringLength(10, MinimumLength = 2)]
    public string? Nationality { get; set; }

    [InverseProperty(nameof(Ticket.Holder))]
    public List<Ticket>? Tickets { get; set; }

#pragma warning disable CS8618
    internal User()
    {
    }
#pragma warning restore CS8618

    public User(string userName, string email, string firstName, string lastName, DateTime birthDate, Gender gender, string? nationality = null) : base(userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentException($"'{nameof(userName)}' cannot be null or whitespace.", nameof(userName));
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentException($"'{nameof(email)}' cannot be null or whitespace.", nameof(email));
        }

        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentException($"'{nameof(firstName)}' cannot be null or whitespace.", nameof(firstName));
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentException($"'{nameof(lastName)}' cannot be null or whitespace.", nameof(lastName));
        }

        Email = email;

        FirstName = firstName;
        LastName = lastName;
        Birthdate = birthDate;
        Gender = gender;
        Nationality = nationality;
    }
}
