using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Matches;
using ReservationSystem.Data.Reservations;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class MatchRepository : BaseRepository<Match>, IMatchRepository
{
    private readonly DbSet<Ticket> _ticketsSet;

    public MatchRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
        _ticketsSet = _dbContext.Set<Ticket>();
    }

    public Task<Match?> FindAsync(int id)
    {
        return _entitySet.Include(m => m.Tickets).SingleOrDefaultAsync(m => m.Id == id);
    }

    public override async Task AddAsync(Match match)
    {
        if (match is null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        if (match.DateTime < DateTime.UtcNow.AddDays(1))
        {
            throw new Exception("Match cannot be scheduled less than one day before its time.");
        }

        var teamConflict = await _entitySet
            .AnyAsync(m => m.DateTime.Date == match.DateTime.Date &&
            (m.HomeTeamName == match.HomeTeamName || m.HomeTeamName == match.AwayTeamName ||
            m.AwayTeamName == match.HomeTeamName || m.AwayTeamName == match.AwayTeamName)).ConfigureAwait(false);

        if (teamConflict)
        {
            throw new Exception("Match cannot be scheduled on the same day as another match for the same team.");
        }

        var stadiumConflict = _entitySet
            .Where(m => m.StadiumName == match.StadiumName)
            .AsEnumerable()
            .Any(m => Math.Abs((m.DateTime - match.DateTime).TotalHours) < 3);

        if (stadiumConflict)
        {
            throw new Exception("Match cannot be scheduled within 3 hours as another match for the same stadium.");
        }

        await base.AddAsync(match).ConfigureAwait(false);

        await UpdateTickets(match).ConfigureAwait(false);
    }

    public override async Task UpdateAsync(Match match)
    {
        if (match is null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        var teamConflict = await _entitySet
            .AnyAsync(m => m.DateTime.Date == match.DateTime.Date &&
            (m.HomeTeamName == match.HomeTeamName || m.HomeTeamName == match.AwayTeamName ||
            m.AwayTeamName == match.HomeTeamName || m.AwayTeamName == match.AwayTeamName)).ConfigureAwait(false);

        if (teamConflict)
        {
            throw new Exception("Match cannot be scheduled on the same day as another match for the same team.");
        }

        var stadiumConflict = _entitySet
            .Where(m => m.StadiumName == match.StadiumName)
            .AsEnumerable()
            .Any(m => Math.Abs((m.DateTime - match.DateTime).TotalHours) < 3);

        if (stadiumConflict)
        {
            throw new Exception("Match cannot be scheduled within 3 hours as another match for the same stadium.");
        }

        await base.UpdateAsync(match).ConfigureAwait(false);

        var tickets = await _ticketsSet.Where(t => t.MatchId == match.Id).ToListAsync().ConfigureAwait(false);
        _ticketsSet.RemoveRange(tickets);

        await UpdateTickets(match).ConfigureAwait(false);
    }

    public new IEnumerable<MatchInfo> Get(int skip, int take)
    {
        return base.Get(skip, take).Include(m => m.Stadium).Include(m => m.Tickets).Select(m => new MatchInfo(m));
    }

    public async Task<MatchDetailedInfo?> GetAsync(int id)
    {
        var match = await _entitySet.Include(m => m.Stadium).Include(m => m.Tickets).SingleOrDefaultAsync(m => m.Id == id);
        if (match is null)
        {
            return null;
        }

        return new MatchDetailedInfo(match);
    }

    private Task UpdateTickets(Match match)
    {
        var stadium = match.Stadium!;
        var tickets = new List<Ticket>(stadium.Rows * stadium.Columns);
        for (int i = 1; i <= stadium.Rows; i++)
        {
            for (int j = 1; j <= stadium.Columns; j++)
            {
                var ticket = new Ticket
                {
                    MatchId = match.Id,
                    Row = i,
                    Column = j,
                };

                tickets.Add(ticket);
            }
        }

        return _ticketsSet.AddRangeAsync(tickets);
    }
}
