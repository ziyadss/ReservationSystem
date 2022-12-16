namespace ReservationSystem.DataStructures.Tickets;

/// <summary>
/// The payload for tickets.
/// </summary>
public class TicketsPayload
{
    /// <summary>
    /// The seats.
    /// </summary>
    public required string[] TicketNumbers { get; set; }
}
