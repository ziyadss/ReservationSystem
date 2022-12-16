using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures.Stadiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IStadiumRepository : IRepository<Stadium>
{
    new IEnumerable<StadiumInfo> Get(int skip, int take);

    Task<StadiumDetailedInfo?> GetAsync(string name);
}
