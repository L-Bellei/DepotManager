using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.API.Data.EntitiesConfiguration;

public sealed class ProductConfiguration : BaseEntityTypeConfiguration<Product>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Product> builder)
    {
        builder
            .ToTable("Products");

        builder.Property(p => p.Name)
            .IsRequired();

        builder.Property(p => p.Description)
            .IsRequired();

        builder.Property(p => p.ProductType)
            .IsRequired()
            .HasConversion<int>();

        builder.Property(p => p.ProductType)
          .IsRequired()
          .HasConversion<int>();

        builder.Property(p => p.SectorId)
               .IsRequired();

        builder.HasIndex(p => p.SectorId);

        builder.HasIndex(p => new 
            { 
                p.SectorId, 
                p.Name 
            })
            .IsUnique();

        builder.HasOne(p => p.Sector)
            .WithMany(s => s.Products)
            .HasForeignKey(p => p.SectorId)
            .OnDelete(DeleteBehavior.Restrict)
            .HasConstraintName("FK_Products_Sectors_SectorId");
    }
}
