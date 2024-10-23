using Kal3ndyla.Core.Products;
using Kal3ndyla.Core.Tracks;
using Kal3ndyla.Persistence.Models;

namespace Kal3ndyla.Infrastructure.Extensions;

public static class ProductExtensions
{
    public static TrackModel ToTrackModel(this Product<TrackFields> track)
        => new()
        {
            Guid = track.Guid,
            Author = track.Author,
            Title = track.Title,
            Duration = track.Fields.Duration,
            Release = null
        };
}