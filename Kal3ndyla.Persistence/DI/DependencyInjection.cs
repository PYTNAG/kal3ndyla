using Kal3ndyla.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Kal3ndyla.Persistence.DI;

public static class DependencyInjection
{
    public static void AddPersistence(this IServiceCollection services, PersistenceConfig config)
    {
        services.AddDbContext<Kal3ndylaContext>(options => options.UseNpgsql(config.ConnectionString), ServiceLifetime.Singleton);
    }
}