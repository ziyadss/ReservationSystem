using ReservationSystem.Data.Tickets;
using ReservationSystem.DataStructures.Matches;
using System;

namespace ReservationSystem.DataStructures.Tickets;

/// <summary>
/// Information about a ticket.
/// </summary>
public class TicketInfo : TicketBriefInfo
{
    /// <summary>
    /// The match.
    /// </summary>
    public MatchBriefInfo Match { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="TicketInfo"/>.
    /// </summary>
    /// <param name="ticket">The ticket.</param>
    public TicketInfo(Ticket ticket) : base(ticket)
    {
        if (ticket.Match is null)
        {
            throw new ArgumentException($"{nameof(ticket)}.{nameof(ticket.Match)} may not be null to create an instance of {nameof(TicketInfo)}");
        }

        Match = new MatchBriefInfo(ticket.Match);
    }
}
