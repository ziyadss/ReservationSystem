using ReservationSystem.Data.Matches;
using System;
using System.Linq;

namespace ReservationSystem.DataStructures.Matches;

/// <summary>
/// Information about a match.
/// </summary>
public class MatchInfo : MatchBriefInfo
{
    /// <summary>
    /// The stadium capacity.
    /// </summary>
    public int StadiumCapacity { get; set; }

    /// <summary>
    /// The number of empty seats.
    /// </summary>
    public int EmptySeats { get; set; }

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
    /// Creates a new instance of <see cref="MatchInfo"/>.
    /// </summary>
    /// <param name="match">The match.</param>
    public MatchInfo(Match match) : base(match)
    {
        if (match.Stadium is null)
        {
            throw new ArgumentException($"{nameof(match)}.{nameof(match.Stadium)} may not be null to create an instance of {nameof(MatchInfo)}");
        }

        if (match.Tickets is null)
        {
            throw new ArgumentException($"{nameof(match)}.{nameof(match.Tickets)} may not be null to create an instance of {nameof(MatchInfo)}");
        }

        StadiumCapacity = match.Stadium.Capacity;
        EmptySeats = match.Tickets.Count(t => t.ReservationId is null);
        Referee = match.Referee;
        FirstLinesman = match.FirstLinesman;
        SecondLinesman = match.SecondLinesman;
    }
}
