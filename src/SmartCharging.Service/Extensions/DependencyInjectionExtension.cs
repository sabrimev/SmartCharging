using SmartCharging.Domain.Data.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;
using SmartCharging.Domain.Data.EntityFramework;
using SmartCharging.Service.Business.Groups.Services;
using SmartCharging.Service.Business.Connectors.Services;
using SmartCharging.Service.Business.ChargeStations.Services;

namespace SmartCharging.Service.Extensions;

public static class DependencyInjectionExtension
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<DataContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        // Services
        services.AddTransient<IGroupService, GroupService>();
        services.AddTransient<IChargeStationService, ChargeStationService>();
        services.AddTransient<IConnectorService, ConnectorService>();
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}