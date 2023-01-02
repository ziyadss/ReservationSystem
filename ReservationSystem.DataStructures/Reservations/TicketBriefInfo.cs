using ReservationSystem.Data.Reservations;

namespace ReservationSystem.DataStructures.Reservations;

/// <summary>
/// Brief information about a ticket.
/// </summary>
public class TicketBriefInfo
{
    /// <summary>
    /// The ticket number.
    /// </summary>
    public string TicketNumber { get; set; }

    /// <summary>
    /// The seat row.
    /// </summary>
    public int Row { get; set; }

    /// <summary>
    /// The seat column.
    /// </summary>
    public int Column { get; set; }

    /// <summary>
    /// Creates a new instance of <see cref="TicketBriefInfo"/>.
    /// </summary>
    /// <param name="ticket">The ticket.</param>
    public TicketBriefInfo(Ticket ticket)
    {
        TicketNumber = ticket.TicketNumber;
        Row = ticket.Row;
        Column = ticket.Column;
    }
}
