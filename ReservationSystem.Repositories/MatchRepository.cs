using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Matches;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class MatchRepository : BaseRepository<Match>, IMatchRepository
{
    public MatchRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
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
