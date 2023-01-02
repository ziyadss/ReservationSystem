using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ReservationSystem.Data;
using ReservationSystem.Data.Reservations;
using ReservationSystem.DataStructures.Reservations;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class ReservationRepository : BaseRepository<Reservation>, IReservationRepository
{
    public ReservationRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
    }

    public Task<int> CountAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        return _entitySet.CountAsync(r => r.HolderUserName == userName);
    }

    public async Task Cancel(string userName, int reservationId)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        var reservation = await _entitySet
            .Include(r => r.Tickets!)
            .ThenInclude(t => t.Match)
            .SingleOrDefaultAsync(r => r.Id == reservationId)
            .ConfigureAwait(false);

        if (reservation is null)
        {
            throw new Exception($"Reservation with reservationId {reservationId} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(reservation.HolderUserName) || reservation.HolderUserName != userName)
        {
            throw new Exception($"Reservation {reservationId} is not booked by {userName}.");
        }

        var matches = reservation.Tickets!.Select(t => t.Match!);
        var match = matches.First();
        if (matches.Any(m => m.Id != match.Id))
        {
            throw new Exception($"Reservation {reservationId} contains tickets for more than one match.");
        }

        if (DateTime.UtcNow.AddDays(3) > match.DateTime)
        {
            throw new Exception($"Reservation {reservationId} cannot be cancelled because the match is in less than 3 days.");
        }

        await RemoveAsync(reservation).ConfigureAwait(false);
    }

    public IEnumerable<ReservationInfo> Get(string userName, int skip, int take)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        return _entitySet
            .Include(r => r.Tickets!)
            .ThenInclude(t => t.Match)
            .Where(r => r.HolderUserName == userName)
            .Skip(skip)
            .Take(take)
            .Select(Map);
    }

    private static ReservationInfo Map(Reservation reservation)
    {
        var matches = reservation.Tickets!.Select(t => t.Match!);
        var match = matches.First();

        if (matches.Any(m => m.Id != match.Id))
        {
            throw new Exception($"Reservation {reservation.Id} contains tickets for more than one match.");
        }

        return new ReservationInfo(reservation, match);
    }

    public Task<ReservationInfo> BookTickets(string userName, IList<(int, int, int)> seats)
    {
        //if (string.IsNullOrWhiteSpace(userName))
        //{
        //    throw new ArgumentNullException(nameof(userName));
        //}

        //var booked = new List<Ticket>(seats.Count);

        //try
        //{
        //    foreach (var (matchId, row, column) in seats)
        //    {
        //        var ticket = await base.FindAsync(matchId, row, column).ConfigureAwait(false);
        //        if (ticket is null)
        //        {
        //            throw new Exception($"Ticket with matchId {matchId}, row {row}, and column {column} does not exist.");
        //        }

        //        if (!string.IsNullOrWhiteSpace(ticket.HolderUserName))
        //        {
        //            throw new Exception($"Ticket {ticket.TicketNumber} is already booked, by {ticket.HolderUserName}.");
        //        }

        //        ticket.HolderUserName = userName;
        //        await UpdateAsync(ticket).ConfigureAwait(false);
        //        booked.Add(ticket);
        //    }
        //}
        //catch
        //{
        //    foreach (var ticket in booked)
        //    {
        //        ticket.HolderUserName = null;
        //        await UpdateAsync(ticket).ConfigureAwait(false);
        //    }

        //    throw;
        //}

        //return booked.Select(t => new TicketBriefInfo(t));
        throw new NotImplementedException();
    }
}
