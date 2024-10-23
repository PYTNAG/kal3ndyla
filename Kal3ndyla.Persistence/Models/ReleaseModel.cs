using Kal3ndyla.Persistence.Configurations;
using Kal3ndyla.Persistence.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace Kal3ndyla.Persistence.Models;

[EntityTypeConfiguration(typeof(ReleaseModelConfiguration))]
public class ReleaseModel : ProductModelBase
{
    public required string Type { get; set; }

    public ICollection<TrackModel>? Tracks { get; set; }
}