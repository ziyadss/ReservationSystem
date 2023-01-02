using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Matches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IMatchRepository : IRepository<Match>
{
    Task<Match?> FindAsync(int id);

    new IEnumerable<MatchInfo> Get(int skip, int take);

    Task<MatchDetailedInfo?> GetAsync(int id);

    Task<MatchDetailedInfo?> GetNextAsync();
}
