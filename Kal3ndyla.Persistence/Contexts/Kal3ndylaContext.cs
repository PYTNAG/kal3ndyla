using Kal3ndyla.Persistence.Models;
using Microsoft.EntityFrameworkCore;

namespace Kal3ndyla.Persistence.Contexts;

public class Kal3ndylaContext : DbContext
{
    public DbSet<TrackModel> Tracks => Set<TrackModel>();
    public DbSet<ReleaseModel> Releases => Set<ReleaseModel>();

    public Kal3ndylaContext(DbContextOptions<Kal3ndylaContext> contextOptions) : base(contextOptions)
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    }
}