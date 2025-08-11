using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.API.Data.EntitiesConfiguration;

public sealed class AddressConfiguration : BaseEntityTypeConfiguration<Address>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Address> builder)
    {
        builder
            .ToTable("Addresses");

        builder.Property(a => a.Street)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(a => a.Number)
            .IsRequired();

        builder.Property(a => a.City)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(a => a.Region)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(a => a.PostalCode)
            .IsRequired()
            .HasMaxLength(20);

        builder.Property(a => a.Country)
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(a => a.Phone)
            .IsRequired()
            .HasMaxLength(30);

        builder.HasIndex(a => new
        {
            a.PostalCode,
            a.Street,
            a.Number
        });
    }
}