using ReservationSystem.Data.Matches;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReservationSystem.Data.Stadiums;

public class Stadium
{
    [Key]
    public required string Name { get; set; }

    public required int Rows { get; set; }

    public required int Columns { get; set; }

    [InverseProperty(nameof(Match.Stadium))]
    public List<Match>? Matches { get; set; }

    [NotMapped]
    public int Capacity => Rows * Columns;
}
