using ReservationSystem.Data.Matches;
using ReservationSystem.DataStructures.Matches;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IMatchRepository : IRepository<Match>
{
    new IEnumerable<MatchInfo> Get(int skip, int take);

    Task<MatchDetailedInfo?> GetAsync(int id);
}
