using ReservationSystem.Data.Matches;
using System;

namespace ReservationSystem.DataStructures.Matches;

/// <summary>
/// Brief information about a match.
/// </summary>
public class MatchBriefInfo
{
    /// <summary>
    /// The match id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The home team name.
    /// </summary>
    public string HomeTeam { get; set; }

    /// <summary>
    /// The away team name.
    /// </summary>
    public string AwayTeam { get; set; }

    /// <summary>
    /// The match stadium.
    /// </summary>    
    public string Stadium { get; set; }

    /// <summary>
    /// The match time.
    /// </summary>
    public DateTime Time { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="MatchBriefInfo"/>.
    /// </summary>
    /// <param name="match">The match.</param>
    public MatchBriefInfo(Match match)
    {
        Id = match.Id;
        HomeTeam = match.HomeTeamName;
        AwayTeam = match.AwayTeamName;
        Stadium = match.StadiumName;
        Time = match.DateTime;
    }
}
