using DotNetAngular.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetAngular.Data.Mapping.Vehicles
{
    public class VehicleMap : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.ToTable("vehicle");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.ChassisId)
                .HasDatabaseName("AK_Vehicle1")
                .IsUnique();

            builder.Property(x => x.ChassisId).IsRequired().HasColumnType("integer");
            builder.Property(x => x.NumberPassengers).IsRequired().HasColumnType("integer");
            builder.Property(x => x.VehicleTypeId).IsRequired().HasColumnType("integer");
            builder.Property(x => x.Color).IsRequired().IsUnicode().HasMaxLength(20);
            builder.Property(x => x.CreateAt).HasColumnType("timestamp");
            builder.Property(x => x.UpdateAt).HasColumnType("timestamp");

            builder.HasOne(v => v.Chassis)
                .WithMany(c => c.Vehicles)
                .HasForeignKey(v => v.ChassisId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_CHASSIS_VEHICLE");

            builder.HasOne(v => v.VehicleType)
                .WithMany(t => t.Vehicles)
                .HasForeignKey(v => v.VehicleTypeId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_VEHICLETYPE_VEHICLE");
        }
    }
}
