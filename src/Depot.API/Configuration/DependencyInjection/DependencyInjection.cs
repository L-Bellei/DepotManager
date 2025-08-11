using Depot.API.Data;
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
    }
}
