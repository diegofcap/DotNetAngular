using DotNetAngular.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetAngular.Data.Mapping.Vehicles
{
    public class VehicleTypeMap : IEntityTypeConfiguration<VehicleType>
    {
        public void Configure(EntityTypeBuilder<VehicleType> builder)
        {
            builder.ToTable("vehicletype");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => e.Name)
                .HasDatabaseName("AK_VehicleType1")
                .IsUnique();

            builder.Property(x => x.Name).IsRequired().IsUnicode(false);
            builder.Property(x => x.CreateAt).HasColumnType("timestamp");
            builder.Property(x => x.UpdateAt).HasColumnType("timestamp");
        }
    }
}
