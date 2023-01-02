using ReservationSystem.Data.Matches;
using ReservationSystem.Data.Reservations;
using ReservationSystem.DataStructures.Matches;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ReservationSystem.DataStructures.Reservations;

/// <summary>
/// Information about a ticket.
/// </summary>
public class ReservationInfo
{
    /// <summary>
    /// The reservation id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// The match.
    /// </summary>
    public MatchBriefInfo Match { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public List<TicketBriefInfo> Tickets { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="ReservationInfo"/>.
    /// </summary>
    /// <param name="reservation">The reservation.</param>
    /// <param name="match">The match.</param>
    public ReservationInfo(Reservation reservation, Match match)
    {
        if (reservation.Tickets is null)
        {
            throw new ArgumentException($"{nameof(reservation)}.{nameof(reservation.Tickets)} may not be null to create an instance of {nameof(ReservationInfo)}");
        }

        Id = reservation.Id;
        Match = new MatchBriefInfo(match);
        Tickets = reservation.Tickets.Select(t => new TicketBriefInfo(t)).ToList();
    }
}
