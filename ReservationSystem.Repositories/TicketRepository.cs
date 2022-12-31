using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Tickets;
using ReservationSystem.DataStructures.Tickets;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class TicketRepository : BaseRepository<Ticket>, ITicketRepository
{
    public TicketRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<IEnumerable<TicketBriefInfo>> BookTickets(string userName, IEnumerable<(int, int, int)> seats)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        var booked = new List<Ticket>(seats.Count());

        try
        {
            foreach (var (matchId, row, column) in seats)
            {
                var ticket = await base.FindAsync(matchId, row, column).ConfigureAwait(false);
                if (ticket is null)
                {
                    throw new Exception($"Ticket with matchId {matchId}, row {row}, and column {column} does not exist.");
                }

                if (!string.IsNullOrWhiteSpace(ticket.HolderUserName))
                {
                    throw new Exception($"Ticket {ticket.TicketNumber} is already booked, by {ticket.HolderUserName}.");
                }

                ticket.HolderUserName = userName;
                await UpdateAsync(ticket).ConfigureAwait(false);
                booked.Add(ticket);
            }
        }
        catch
        {
            foreach (var ticket in booked)
            {
                ticket.HolderUserName = null;
                await UpdateAsync(ticket).ConfigureAwait(false);
            }

            throw;
        }

        return booked.Select(t => new TicketBriefInfo(t));
    }

    public async Task CancelTicket(string userName, int matchId, int row, int column)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        var ticket = await _entitySet.Include(t => t.Match).SingleOrDefaultAsync(t => t.MatchId == matchId && t.Row == row && t.Column == column).ConfigureAwait(false);
        if (ticket is null)
        {
            throw new Exception($"Ticket with matchId {matchId}, row {row}, and column {column} does not exist.");
        }

        if (string.IsNullOrWhiteSpace(ticket.HolderUserName) || ticket.HolderUserName != userName)
        {
            throw new Exception($"Ticket {ticket.TicketNumber} is not booked by {userName}.");
        }

        if (DateTime.UtcNow.AddDays(3) > ticket.Match!.DateTime)
        {
            throw new Exception($"Ticket {ticket.TicketNumber} cannot be cancelled because the match is in less than 3 days.");
        }

        ticket.HolderUserName = null;
        await UpdateAsync(ticket).ConfigureAwait(false);
    }

    public async Task<TicketInfo?> FindAsync(int matchId, int row, int column)
    {
        var ticket = await _entitySet.Include(t => t.Match).SingleOrDefaultAsync(t => t.MatchId == matchId && t.Row == row && t.Column == column).ConfigureAwait(false);
        if (ticket is null)
        {
            return null;
        }

        return new TicketInfo(ticket);
    }

    public IEnumerable<TicketInfo> Get(string userName, int skip, int take)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        return _entitySet.Include(t => t.Match).Where(t => t.HolderUserName == userName).Skip(skip).Take(take).Select(t => new TicketInfo(t));
    }

    public Task<int> CountAsync(string userName)
    {
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentNullException(nameof(userName));
        }

        return _entitySet.CountAsync(t => t.HolderUserName == userName);
    }
}
