using Kal3ndyla.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Kal3ndyla.Persistence.Models;

[EntityTypeConfiguration(typeof(TrackModelConfiguration))]
public class TrackModel : Base.ProductModelBase
{
    public TimeSpan Duration { get; set; }

    public ReleaseModel? Release { get; set; }
}