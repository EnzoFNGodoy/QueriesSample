using Microsoft.EntityFrameworkCore;
using QueriesSample.Infra.Data.Context;

namespace QueriesSample.WebApi.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services)
    {
        if (services is null) throw new ArgumentNullException(nameof(services));

        services.AddDbContext<QueriesSampleContext>(options => 
        options.UseInMemoryDatabase("QueriesSampleDB"));
    }
}