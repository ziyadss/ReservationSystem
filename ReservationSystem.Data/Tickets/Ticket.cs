using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data.Matches;
using ReservationSystem.Data.Users;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ReservationSystem.Data.Tickets;

[PrimaryKey(nameof(MatchId), nameof(Row), nameof(Column))]
[Index(nameof(HolderUserName))]
[Index(nameof(MatchId))]
public class Ticket
{
    [Required]
    [ForeignKey(nameof(Match))]
    public int MatchId { get; set; }

    [InverseProperty(nameof(Matches.Match.Tickets))]
    public Match? Match { get; set; }

    public required int Row { get; set; }

    public required int Column { get; set; }

    [ForeignKey(nameof(User))]
    public string? HolderUserName { get; set; }

    [InverseProperty(nameof(User.Tickets))]
    public User? Holder { get; set; }

    public string TicketNumber => $"{MatchId}-{Row}-{Column}";
}
