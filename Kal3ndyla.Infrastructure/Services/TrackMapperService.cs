using Kal3ndyla.Core.Products;
using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Infrastructure.Services.Interfaces;
using Kal3ndyla.Persistence.Models;

namespace Kal3ndyla.Infrastructure.Services;

public class TrackMapperService : IPersistenceMapperService<TrackModel, Product<TrackFields>>
{
    public Product<TrackFields> ToDto(TrackModel model)
    {
        var fields = new TrackFields(model.Duration, model.Release);
        return new Product<TrackFields>()
    }

    public TrackModel ToModel(Product<TrackFields> dto)
    {
        throw new NotImplementedException();
    }
}