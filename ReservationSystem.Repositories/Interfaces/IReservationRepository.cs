using ReservationSystem.Data.Reservations;
using ReservationSystem.DataStructures.Reservations;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IReservationRepository : IRepository<Reservation>
{
    Task<ReservationInfo> BookTickets(string userName, IList<(int, int, int)> seats);

    Task Cancel(string userName, int reservationId);

    IEnumerable<ReservationInfo> Get(string userName, int skip, int take);

    Task<int> CountAsync(string userName);
}
