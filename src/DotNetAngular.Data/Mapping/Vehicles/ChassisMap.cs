using DotNetAngular.Core.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DotNetAngular.Data.Mapping.Vehicles
{
    public class ChassisMap : IEntityTypeConfiguration<Chassis>
    {
        public void Configure(EntityTypeBuilder<Chassis> builder)
        {
            builder.ToTable("chassis");
            builder.HasKey(x => x.Id);
            builder.HasIndex(e => new { e.Number, e.Series })
                .HasDatabaseName("AK_Chassis1")
                .IsUnique();

            builder.Property(x => x.Number).IsRequired().HasColumnType("integer");
            builder.Property(x => x.Series).IsRequired().IsUnicode(false);
            builder.Property(x => x.CreateAt).HasColumnType("timestamp");
            builder.Property(x => x.UpdateAt).HasColumnType("timestamp");
        }
    }
}
