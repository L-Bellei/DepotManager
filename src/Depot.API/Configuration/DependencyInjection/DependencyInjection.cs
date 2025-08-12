using Depot.API.Common.Interfaces.Repositories;
using Depot.API.Common.Repositories;
using Depot.API.Data;
using Depot.API.Features.Registrations.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Depot.API.Configuration.DependencyInjection;

public static class DependencyInjection
{
    public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
    {
        var conn = configuration.GetConnectionString("DepotConn")!;

        services.AddDbContextPool<DepotContext>(opt =>
            opt.UseNpgsql(conn, npgsql => npgsql.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery))
            .UseSnakeCaseNamingConvention()
        );

        services.AddSingleton(configuration);

        services.AddScoped<IAddressRepository, AddressRepository>();
        services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<ISectorRepository, SectorRepository>();

        services.AddRegistrationFeature();
    }
}
