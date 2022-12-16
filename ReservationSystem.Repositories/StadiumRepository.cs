using Microsoft.EntityFrameworkCore;
using ReservationSystem.Data;
using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures.Stadiums;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public class StadiumRepository : BaseRepository<ReservationSystemDbContext, Stadium>, IStadiumRepository
{
    public StadiumRepository(ReservationSystemDbContext dbContext) : base(dbContext)
    {
    }

    public new IEnumerable<StadiumInfo> Get(int skip, int take)
    {
        return base.Get(skip, take).Select(s => new StadiumInfo(s));
    }

    public async Task<StadiumDetailedInfo?> GetAsync(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentNullException(nameof(name));
        }

        var stadium = await _entitySet.Include(s => s.Matches).SingleOrDefaultAsync(s => s.Name == name).ConfigureAwait(false);
        if (stadium is null)
        {
            return null;
        }

        return new StadiumDetailedInfo(stadium);
    }
}
