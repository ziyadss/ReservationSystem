using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories.Interfaces;

public interface IRepository<TEntity>
{
    Task<int> CountAsync();

    Task<TEntity> FindAsync(params object[] keyValues);

    IQueryable<TEntity> Get(int skip, int take);

    Task AddAsync(TEntity item);

    Task UpdateAsync(TEntity item);

    Task RemoveAsync(object key);

    Task RemoveAsync(TEntity item);
}
