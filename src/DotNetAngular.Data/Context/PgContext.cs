using DotNetAngular.Core.Domain.Vehicles;
using DotNetAngular.Data.Mapping.Vehicles;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;

namespace DotNetAngular.Data.Context
{
    public class PgContext : DbContext 
    {
        public DbSet<Chassis> Chassis { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public PgContext(DbContextOptions<PgContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder
                .UseNpgsql("Host=dotnetangular.db;Port=5432;Database=dotnetangular;Username=postgres;Password=#d0tn3t#", b=> b.MigrationsAssembly("DotNetAngular.Data"))
                .UseLowerCaseNamingConvention();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.UseSerialColumns();
            modelBuilder.Entity<Chassis>(new ChassisMap().Configure);
            modelBuilder.Entity<VehicleType>(new VehicleTypeMap().Configure);
            modelBuilder.Entity<Vehicle>(new VehicleMap().Configure);
        }
    }
}
