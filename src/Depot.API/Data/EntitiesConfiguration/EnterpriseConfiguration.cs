using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.API.Data.EntitiesConfiguration;

public sealed class EnterpriseConfiguration : BaseEntityTypeConfiguration<Enterprise>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Enterprise> builder)
    {
        builder
            .ToTable("Enterprises");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(e => e.Description)
            .HasMaxLength(500);

        builder.Property(e => e.AddressId)
            .IsRequired();
        
        builder.HasIndex(e => e.AddressId)
            .IsUnique();

        builder.HasOne(e => e.Address)
            .WithOne(a => a.Enterprise)
            .HasForeignKey<Enterprise>(e => e.AddressId)
            .OnDelete(DeleteBehavior.Restrict) 
            .HasConstraintName("FK_Enterprises_Address");
    }
}