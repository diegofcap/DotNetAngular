using DotNetAngular.Core.Domain.Vehicles;
using DotNetAngular.Data.Mapping.Vehicles;
using Microsoft.EntityFrameworkCore;
using EFCore.NamingConventions;
using Microsoft.Extensions.Configuration;

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
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            optionsBuilder
                .UseNpgsql(configuration.GetConnectionString("Default"), b => b.MigrationsAssembly("DotNetAngular.Data"))
                .UseLowerCaseNamingConvention();
        }

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
