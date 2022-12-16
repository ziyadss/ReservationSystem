using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures.Matches;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationSystem.DataStructures.Stadiums;

/// <summary>
/// Detailed information about a stadium.
/// </summary>
public class StadiumDetailedInfo : StadiumInfo
{
    /// <summary>
    /// The number of rows.
    /// </summary>
    public int Rows { get; set; }

    /// <summary>
    /// The number of columns.
    /// </summary>
    public int Columns { get; set; }

    /// <summary>
    /// The matches taking place in the stadium.
    /// </summary>
    public IEnumerable<MatchBriefInfo> Matches { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="StadiumDetailedInfo"/>.
    /// </summary>
    /// <param name="stadium">The stadium.</param>
    public StadiumDetailedInfo(Stadium stadium) : base(stadium)
    {
        if (stadium.Matches is null)
        {
            throw new ArgumentException($"{nameof(stadium)}.{nameof(stadium.Matches)} may not be null to create an instance of {nameof(StadiumDetailedInfo)}");
        }

        Rows = stadium.Rows;
        Columns = stadium.Columns;
        Matches = stadium.Matches.Select(m => new MatchBriefInfo(m));
    }
}
