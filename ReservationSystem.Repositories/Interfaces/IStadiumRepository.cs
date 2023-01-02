using ReservationSystem.Data.Stadiums;
using ReservationSystem.DataStructures.Stadiums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IStadiumRepository : IRepository<Stadium>
{
    IEnumerable<StadiumInfo> Get();

    Task<StadiumDetailedInfo?> GetAsync(string name);
}
