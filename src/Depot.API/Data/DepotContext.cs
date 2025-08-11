using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Depot.API.Data;

public class DepotContext(DbContextOptions<DepotContext> options) : DbContext(options)
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Sector> Sectors { get; set; }
    public DbSet<Enterprise> Enterprises { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Address> Addresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(DepotContext).Assembly);

        modelBuilder.Entity<Enterprise>()
            .Navigation(e => e.Address)
            .AutoInclude();

        
        base.OnModelCreating(modelBuilder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Properties<decimal>()
            .HavePrecision(18, 2);

        base.ConfigureConventions(configurationBuilder);
    }
}
