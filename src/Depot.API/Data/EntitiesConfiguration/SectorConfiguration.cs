using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.API.Data.EntitiesConfiguration;

public sealed class SectorConfiguration : BaseEntityTypeConfiguration<Sector>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Sector> builder)
    {
        builder
            .ToTable("Sectors");

        builder.Property(s => s.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(s => s.Description)
            .HasMaxLength(500);

        builder.Property(s => s.ResponsibleEmployee)
            .IsRequired(false);

        builder.HasIndex(s => s.Name);

        builder.HasMany(s => s.Employees)
            .WithOne(e => e.Sector)
            .HasForeignKey(e => e.SectorId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasOne(s => s.Responsible)
            .WithMany()
            .HasForeignKey(s => s.ResponsibleEmployee)
            .OnDelete(DeleteBehavior.SetNull)
            .HasConstraintName("FK_Sectors_ResponsibleEmployee");

        builder.HasMany(s => s.Enterprises)
           .WithMany(e => e.Sectors)
           .UsingEntity<Dictionary<string, object>>(
            "EnterpriseSectors",
                right => right
                    .HasOne<Enterprise>()
                    .WithMany()
                    .HasForeignKey("EnterpriseId")
                    .OnDelete(DeleteBehavior.Cascade),
                left => left
                    .HasOne<Sector>()
                    .WithMany()
                    .HasForeignKey("SectorId")
                    .OnDelete(DeleteBehavior.Cascade),
                join =>
                {
                    join.ToTable("EnterpriseSectors");
                    join.HasKey("EnterpriseId", "SectorId");
                    join.HasIndex("SectorId");
                    join.HasIndex("EnterpriseId");
                });
    }
}
