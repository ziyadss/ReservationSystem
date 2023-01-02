using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Reservations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationSystem.DataStructures.Matches;

/// <summary>
/// Detailed information about a match.
/// </summary>
public class MatchDetailedInfo : MatchInfo
{
    /// <summary>
    /// The available seats.
    /// </summary>
    public IEnumerable<TicketBriefInfo> AvailableSeats { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="MatchDetailedInfo"/>.
    /// </summary>
    /// <param name="match">The match.</param>
    public MatchDetailedInfo(Match match) : base(match)
    {
        if (match.Tickets is null)
        {
            throw new ArgumentException($"{nameof(match)}.{nameof(match.Tickets)} may not be null to create an instance of {nameof(MatchDetailedInfo)}");
        }

        AvailableSeats = match.Tickets.Where(t => t.ReservationId is null).Select(t => new TicketBriefInfo(t));
    }
}
