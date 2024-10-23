using Kal3ndyla.Persistence.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Kal3ndyla.Persistence.Configurations;

public class ReleaseModelConfiguration : IEntityTypeConfiguration<ReleaseModel>
{
    public void Configure(EntityTypeBuilder<ReleaseModel> builder)
    {
        builder.ToTable("Releases");

        builder
            .Property(r => r.Guid)
            .IsRequired();

        builder
            .Property(r => r.Author)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(r => r.Title)
            .IsRequired()
            .HasMaxLength(256);

        builder
            .Property(r => r.Type)
            .IsRequired();

        builder
            .HasIndex(t => t.Guid)
            .IsUnique();

        builder
            .HasMany(r => r.Tracks)
            .WithOne(t => t.Release)
            .HasForeignKey(t => t.Guid);
    }
}