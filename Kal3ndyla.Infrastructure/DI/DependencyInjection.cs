using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Infrastructure.SearchEngine;
using Kal3ndyla.Infrastructure.SearchEngine.Interfaces;
using Kal3ndyla.Infrastructure.Services;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Kal3ndyla.Persistence.DI;
using Kal3ndyla.Persistence.Models;
using Microsoft.Extensions.DependencyInjection;

namespace Kal3ndyla.Infrastructure.DI;

public static class DependencyInjection
{
    public static void AddKal3ndylaInfrastructure(this IServiceCollection services, PersistenceConfig persistenceConfig)
    {
        services.AddPersistence(persistenceConfig);

        services.AddTransient<ISearchEngine<TrackModel, TracksQuery>, TracksSearchEngine>();
        services.AddTransient<ITrackService, TrackService>();
    }
}