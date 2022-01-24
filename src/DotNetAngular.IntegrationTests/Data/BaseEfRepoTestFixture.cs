using DotNetAngular.Api.Framework.DependencyInjection;
using DotNetAngular.Data.Context;
using DotNetAngular.Services.Vehicles;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetAngular.IntegrationTests.Data
{
    public abstract class BaseEfRepoTestFixture
    {
        protected IVehicleService GetService()
        {
            ServiceCollection services = new ServiceCollection();
            ConfigureService.ConfigureDependenciesService(services);

            IConfiguration configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            ConfigureRepository.ConfigureDependenciesRepository(services, configuration);

            var serviceProvider = services.BuildServiceProvider();

            var context = serviceProvider.GetRequiredService<PgContext>();
            DbInitializer.Initialize(context);

            return serviceProvider.GetRequiredService<IVehicleService>();
        }
    }
}
