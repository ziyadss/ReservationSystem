using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data.Stadiums;
using ReservationSystem.Data.Tickets;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Data.Matches;

[Index(nameof(DateTime), IsUnique = false)]
public class Match
{
    [Key]
    public int Id { get; set; }

    //[InverseProperty(nameof(Team.HomeMatches))]
    //public Team? HomeTeam { get; set; }

    //[ForeignKey(nameof(Team))]
    public required string HomeTeamName { get; set; }

    //[InverseProperty(nameof(Team.AwayMatches))]
    //public Team? AwayTeam { get; set; }

    //[ForeignKey(nameof(Team))]
    public required string AwayTeamName { get; set; }

    [InverseProperty(nameof(Stadiums.Stadium.Matches))]
    public Stadium? Stadium { get; set; }

    [ForeignKey(nameof(Stadium))]
    public required string StadiumName { get; set; }

    public DateTime DateTime { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public required string Referee { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public required string FirstLinesman { get; set; }

    [StringLength(100, MinimumLength = 3)]
    public required string SecondLinesman { get; set; }

    [InverseProperty(nameof(Ticket.Match))]
    public List<Ticket>? Tickets { get; set; }
}
