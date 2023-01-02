using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Matches;
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
    private readonly DbSet<Ticket> _ticketsSet;

    public ReservationRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
        _ticketsSet = _dbContext.Set<Ticket>();
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

        if (reservation.HolderUserName != userName)
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
            .Select(r => new ReservationInfo(r, GetReservationMatch(r)));
    }

    public async Task<ReservationInfo> BookTickets(string userName, IList<(int, int, int)> tickets)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        var reservation = new Reservation
        {
            HolderUserName = userName
        };

        await AddAsync(reservation).ConfigureAwait(false);

        var booked = new List<Ticket>(tickets.Count);
        try
        {
            foreach (var t in tickets)
            {
                var ticket = await GetTicket(t).ConfigureAwait(false);

                if (ticket.ReservationId is not null)
                {
                    throw new Exception($"Ticket {ticket.TicketNumber} is already booked.");
                }

                ticket.ReservationId = reservation.Id;
                await UpdateTicket(ticket).ConfigureAwait(false);
                booked.Add(ticket);
            }
        }
        catch
        {
            foreach (var ticket in booked)
            {
                ticket.ReservationId = null;
                await UpdateTicket(ticket).ConfigureAwait(false);
            }

            await RemoveAsync(reservation).ConfigureAwait(false);
            throw;
        }

        await UpdateAsync(reservation).ConfigureAwait(false);

        return new ReservationInfo(reservation, GetReservationMatch(reservation));
    }

    private static Match GetReservationMatch(Reservation reservation)
    {
        var matches = reservation.Tickets!.Select(t => t.Match!).ToList();
        var match = matches.First();

        if (matches.Any(m => m.Id != match.Id))
        {
            throw new Exception($"Reservation {reservation.Id} contains tickets for more than one match.");
        }

        return match;
    }

    private async Task<Ticket> GetTicket((int, int, int) ticket)
    {
        var (matchId, row, column) = ticket;
        var foundTicket = await _ticketsSet
            .Include(t => t.Match)
            .SingleOrDefaultAsync(t => t.MatchId == matchId && t.Row == row && t.Column == column)
            .ConfigureAwait(false);

        if (foundTicket is null)
        {
            throw new Exception($"Ticket with matchId {matchId}, row {row}, and column {column} does not exist.");
        }

        return foundTicket;
    }

    private Task UpdateTicket(Ticket ticket)
    {
        _ticketsSet.Update(ticket);
        return _dbContext.SaveChangesAsync();
    }
}
