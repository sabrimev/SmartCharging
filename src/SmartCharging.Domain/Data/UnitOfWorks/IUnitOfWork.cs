using SmartCharging.Domain.Data.GenericRepositories;
using SmartCharging.Domain.Data.EntityFramework.Entities;

namespace SmartCharging.Domain.Data.UnitOfWorks;

/// <summary>
/// IUnitOfWork
/// </summary>
public interface IUnitOfWork : IDisposable
{
    Task<int> SaveChangesAsync();
    
    GenericRepository<Group, Guid> Group { get; }
    GenericRepository<ChargeStation, Guid> ChargeStation { get; }
    GenericRepository<Connector, int> Connector { get; }
}