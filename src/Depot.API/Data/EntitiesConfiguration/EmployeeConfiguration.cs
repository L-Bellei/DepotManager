using Depot.API.Common.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Depot.API.Data.EntitiesConfiguration;

public class EmployeeConfiguration : BaseEntityTypeConfiguration<Employee>
{
    protected override void ConfigureEntity(EntityTypeBuilder<Employee> builder)
    {
        builder
            .ToTable("Employees");

        builder.Property(e => e.Name)
            .IsRequired()
            .HasMaxLength(120);

        builder.Property(e => e.Age)
            .IsRequired();

        builder.Property(e => e.DateOfBirth)
            .IsRequired()
            .HasColumnType("date");

        builder.HasIndex(e => e.SectorId);

        builder.HasOne(e => e.Sector)
           .WithMany(s => s.Employees)
           .HasForeignKey(e => e.SectorId)
           .OnDelete(DeleteBehavior.Restrict);
    }
}
