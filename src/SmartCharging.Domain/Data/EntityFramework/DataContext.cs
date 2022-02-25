using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SmartCharging.Domain.Data.EntityFramework.Entities;

namespace SmartCharging.Domain.Data.EntityFramework;

/// <summary>
/// DataContext
/// </summary>
public class DataContext : DbContext
{
    #region Groups

    public virtual DbSet<Group> Groups { get; set; }

    #endregion

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
        #region Products

        modelBuilder.ApplyConfiguration(new GroupConf());

        #endregion

        base.OnModelCreating(modelBuilder);
    }
}