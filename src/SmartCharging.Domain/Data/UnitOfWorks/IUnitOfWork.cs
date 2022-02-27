using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.GenericRepositories;

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
