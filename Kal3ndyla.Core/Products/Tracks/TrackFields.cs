using Kal3ndyla.Core.Products;
using Kal3ndyla.Core.Releases;

namespace Kal3ndyla.Core.Tracks;

public class TrackFields(TimeSpan duration, Product<ReleaseFields> release)
{
    public TimeSpan Duration { get; } = duration;
    public Product<ReleaseFields> Release { get; } = release;
}