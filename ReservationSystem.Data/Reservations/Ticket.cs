using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data.Matches;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReservationSystem.Data.Reservations;

[PrimaryKey(nameof(MatchId), nameof(Row), nameof(Column))]
[Index(nameof(ReservationId))]
[Index(nameof(MatchId))]
public class Ticket
{
    [Required]
    [ForeignKey(nameof(Match))]
    public required int MatchId { get; set; }

    [InverseProperty(nameof(Matches.Match.Tickets))]
    public Match? Match { get; set; }

    public required int Row { get; set; }

    public required int Column { get; set; }

    [ForeignKey(nameof(Reservation))]
    public int? ReservationId { get; set; }

    [InverseProperty(nameof(Reservation.Tickets))]
    public Reservation? HeldReservation { get; set; }

    public string TicketNumber => $"{MatchId}-{Row}-{Column}";
}
