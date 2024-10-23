using Kal3ndyla.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kal3ndyla.Persistence.Configurations;

public class TrackModelConfiguration : IEntityTypeConfiguration<TrackModel>
{
    public void Configure(EntityTypeBuilder<TrackModel> builder)
    {
        builder.ToTable("Tracks");

        builder
            .Property(t => t.Guid)
            .IsRequired();

        builder
            .Property(t => t.Author)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(t => t.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(t => t.Duration)
            .IsRequired();

        builder
            .HasIndex(t => t.Guid)
            .IsUnique();

        builder
            .HasOne(t => t.Release)
            .WithMany(r => r.Tracks)
            .HasForeignKey(r => r.Guid);
    }
}