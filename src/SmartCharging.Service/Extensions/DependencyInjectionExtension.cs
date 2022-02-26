using Microsoft.Extensions.DependencyInjection;
using SmartCharging.Domain.Data.EntityFramework;
using SmartCharging.Domain.Data.UnitOfWorks;

namespace SmartCharging.Service.Extensions;

public static class DependencyInjectionExtension
{
    public static void RegisterDependencies(this IServiceCollection services)
    {
        services.AddTransient<DataContext>();
        services.AddTransient<IUnitOfWork, UnitOfWork>();
        
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}

