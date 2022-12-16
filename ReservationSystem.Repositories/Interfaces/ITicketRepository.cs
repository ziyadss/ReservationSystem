using ReservationSystem.Data.Tickets;
using ReservationSystem.DataStructures.Tickets;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface ITicketRepository : IRepository<Ticket>
{
    Task<IEnumerable<TicketBriefInfo>> BookTickets(string userName, IEnumerable<(int, int, int)> seats);

    Task CancelTicket(string userName, int matchId, int row, int column);

    IEnumerable<TicketInfo> Get(string userName, int skip, int take);

    Task<TicketInfo?> FindAsync(int matchId, int row, int column);

    Task<int> CountAsync(string userName);
}
