using DotNetAngular.Data.Context;
using DotNetAngular.Services.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetAngular.Api.Framework.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection services)
        {
            // Transient, create a new instance by use
            services.AddScoped(provider => new PgContext(new DbContextOptions<PgContext>()));
            services.AddTransient<IVehicleService, VehicleService>();
            services.AddTransient<IVehicleTypeService, VehicleTypeService>();
        }
    }
}
