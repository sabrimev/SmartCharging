using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.GenericRepositories;

namespace SmartCharging.Domain.Data.UnitOfWorks;

/// <summary>
/// IUnitOfWork
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();

    #region Repositories

    #region Products

    GenericRepository<Group, Guid> Group { get; }

    #endregion

    #endregion
}
