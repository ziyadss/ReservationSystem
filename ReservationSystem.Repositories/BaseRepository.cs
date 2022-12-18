using Microsoft.EntityFrameworkCore;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public abstract class BaseRepository<TEntity> : IRepository<TEntity>
    where TEntity : class
{
    private readonly DbContext _dbContext;

    protected readonly DbSet<TEntity> _entitySet;

    public BaseRepository(DbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<TEntity>();
    }

    public virtual Task<int> CountAsync()
    {
        return _entitySet.CountAsync();
    }

    public virtual async Task<TEntity?> FindAsync(params object[] keyValues)
    {
        var entity = await _entitySet.FindAsync(keyValues).ConfigureAwait(false);

        return entity;
    }

    public virtual IQueryable<TEntity> Get(int skip, int take)
    {
        return _entitySet.Skip(skip).Take(take);
    }

    public virtual async Task AddAsync(TEntity item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        await _entitySet.AddAsync(item).ConfigureAwait(false);
        await _dbContext.SaveChangesAsync().ConfigureAwait(false);
    }

    public virtual Task UpdateAsync(TEntity item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _entitySet.Update(item);
        return _dbContext.SaveChangesAsync();
    }

    public virtual Task RemoveAsync(TEntity item)
    {
        if (item is null)
        {
            throw new ArgumentNullException(nameof(item));
        }

        _entitySet.Remove(item);
        return _dbContext.SaveChangesAsync();
    }
}
