using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartCharging.Domain.Data.EntityFramework.Entities;
using SmartCharging.Domain.Data.EntityFramework.Configurations;

namespace SmartCharging.Domain.Data.EntityFramework;

/// <summary>
/// DataContext
/// </summary>
public class DataContext : DbContext
{
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<ChargeStation> ChargeStations { get; set; }
    public virtual DbSet<Connector> Connectors { get; set; }
    
    /// <summary>
    /// OnConfiguring
    /// </summary>
    /// <param name="optionsBuilder"></param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        base.OnConfiguring(optionsBuilder);
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{environmentName}.json")
            .Build();

        optionsBuilder.UseSqlServer(configuration.GetConnectionString("Mssql"));
    }

    /// <summary>
    /// OnModelCreating
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new GroupConf());
        
        base.OnModelCreating(modelBuilder);
    }
}