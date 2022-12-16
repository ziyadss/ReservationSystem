using System;

namespace ReservationSystem.DataStructures.Matches;

/// <summary>
/// The payload for a match.
/// </summary>
public class MatchPayload
{
    /// <summary>
    /// The home team name.
    /// </summary>
    public required string HomeTeam { get; set; }

    /// <summary>
    /// The away team name.
    /// </summary>
    public required string AwayTeam { get; set; }

    /// <summary>
    /// The stadium name.
    /// </summary>
    public required string Stadium { get; set; }

    /// <summary>
    /// The date and time of the match.
    /// </summary>
    public required DateTime Time { get; set; }

    /// <summary>
    /// The referee name.
    /// </summary>
    public required string Referee { get; set; }

    /// <summary>
    /// The first linesman name.
    /// </summary>
    public required string FirstLinesman { get; set; }

    /// <summary>
    /// The second linesman name.
    /// </summary>
    public required string SecondLinesman { get; set; }
}
