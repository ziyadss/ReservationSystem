using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Matches;
using ReservationSystem.Data.Tickets;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class MatchRepository : BaseRepository<ReservationSystemDbContext, Match>, IMatchRepository
{
    public MatchRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task AddAsync(Match match)
    {
        if (match is null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        var stadium = await _dbContext.Stadiums.SingleOrDefaultAsync(s => s.Name == match.StadiumName).ConfigureAwait(false);
        if (stadium is null)
        {
            throw new Exception($"Stadium {match.StadiumName} does not exist.");
        }

        var conflict = await _entitySet
            .AnyAsync(m => m.DateTime.Date == match.DateTime.Date &&
            (m.HomeTeamName == match.HomeTeamName || m.HomeTeamName == match.AwayTeamName ||
            m.AwayTeamName == match.HomeTeamName || m.AwayTeamName == match.AwayTeamName ||
            m.StadiumName == match.StadiumName)).ConfigureAwait(false);

        if (conflict)
        {
            throw new Exception("Match cannot be scheduled on the same day as another match for the same stadium or team.");
        }

        match.Tickets = new List<Ticket>(stadium.Rows * stadium.Columns);
        for (int i = 1; i <= stadium.Rows; i++)
        {
            for (int j = 1; j <= stadium.Columns; j++)
            {
                match.Tickets.Add(new Ticket { Row = i, Column = j });
            }
        }

        await base.AddAsync(match).ConfigureAwait(false);
    }

    public override async Task UpdateAsync(Match match)
    {
        if (match is null)
        {
            throw new ArgumentNullException(nameof(match));
        }

        var stadium = await _dbContext.Stadiums.SingleOrDefaultAsync(s => s.Name == match.StadiumName).ConfigureAwait(false);
        if (stadium is null)
        {
            throw new Exception($"Stadium {match.StadiumName} does not exist.");
        }

        var conflict = await _entitySet
            .AnyAsync(m => m.DateTime.Date == match.DateTime.Date && m.Id != match.Id &&
            (m.HomeTeamName == match.HomeTeamName || m.HomeTeamName == match.AwayTeamName ||
            m.AwayTeamName == match.HomeTeamName || m.AwayTeamName == match.AwayTeamName ||
            m.StadiumName == match.StadiumName)).ConfigureAwait(false);

        if (conflict)
        {
            throw new Exception("Match cannot be scheduled on the same day as another match for the same stadium or team.");
        }

        await base.UpdateAsync(match).ConfigureAwait(false);
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
}
