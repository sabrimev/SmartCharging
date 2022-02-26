using SmartCharging.Domain.Data.EntityFramework;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.EntityFramework.Entities.Base;
using SmartCharging.Domain.Data.GenericRepositories;

namespace SmartCharging.Domain.Data.UnitOfWorks;

/// <summary>
/// UnitOfWork
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly DataContext _context;

    #region ctor

    public UnitOfWork(DataContext context)
    {
        _context = context ?? throw new ArgumentException(null, nameof(context));
    }

    #endregion

    #region Repositories

    #region Groups
    private GenericRepository<Group, Guid> _group;
    public GenericRepository<Group, Guid> Group
    {
        get { return _group ??= GetRepositoryT<Group, Guid>(); }
        set => _group = value;
    }

    #endregion

    #endregion

    #region

    /// <summary>
    /// GetRepositoryT
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <returns></returns>
    public GenericRepository<TEntity, TKey> GetRepositoryT<TEntity, TKey>() where TEntity : BaseEntity<TKey>
    {
        var dbSet = _context.Set<TEntity>();
        return new GenericRepository<TEntity, TKey>(dbSet, _context);
    }

    public async Task<int> SaveChangesAsync()
    {
        var result = await _context.SaveChangesAsync();
        return result;
    }

    private bool _disposed;

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposed)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    #endregion
}
