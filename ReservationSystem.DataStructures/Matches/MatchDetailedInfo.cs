using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Tickets;
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
    /// The match referee.
    /// </summary>
    public string Referee { get; set; }

    /// <summary>
    /// The first linesman.
    /// </summary>
    public string FirstLinesman { get; set; }

    /// <summary>
    /// The second linesman.
    /// </summary>
    public string SecondLinesman { get; set; }

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

        Referee = match.Referee;
        FirstLinesman = match.FirstLinesman;
        SecondLinesman = match.SecondLinesman;
        AvailableSeats = match.Tickets.Where(t => string.IsNullOrWhiteSpace(t.HolderUserName)).Select(t => new TicketBriefInfo(t));
    }
}
