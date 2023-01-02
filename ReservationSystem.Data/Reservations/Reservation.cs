using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data.Users;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReservationSystem.Data.Reservations;

[Index(nameof(HolderUserName))]
public class Reservation
{
    [Key]
    public int Id { get; set; }

    [ForeignKey(nameof(User))]
    public string? HolderUserName { get; set; }

    [InverseProperty(nameof(User.Reservations))]
    public User? Holder { get; set; }

    [InverseProperty(nameof(Ticket.HeldReservation))]
    public List<Ticket>? Tickets { get; set; }
}
