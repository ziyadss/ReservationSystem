using Microsoft.EntityFrameworkCore;
using ReservationSystem.Repositories.Interfaces;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ReservationSystem.Repositories;

public abstract class BaseRepository<TDbContext, TEntity> : IRepository<TEntity>
    where TDbContext : DbContext
    where TEntity : class
{
    protected readonly TDbContext _dbContext;
    protected readonly DbSet<TEntity> _entitySet;

    public BaseRepository(TDbContext dbContext)
    {
        _dbContext = dbContext;
        _entitySet = _dbContext.Set<TEntity>();
    }

    public virtual Task<int> CountAsync()
    {
        return _entitySet.CountAsync();
    }

    public virtual async Task<TEntity> FindAsync(params object[] keyValues)
    {
        var entity = await _entitySet.FindAsync(keyValues).ConfigureAwait(false);
        if (entity is null)
        {
            throw new ArgumentException($"Entity with key {keyValues} not found");
        }

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

    public virtual async Task RemoveAsync(object key)
    {
        var entity = await FindAsync(key).ConfigureAwait(false);
        await RemoveAsync(entity).ConfigureAwait(false);
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
