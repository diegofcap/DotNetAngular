using DotNetAngular.Data.Context;
using DotNetAngular.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotNetAngular.Api.Framework.DependencyInjection
{
    public class ConfigureRepository
    {
        public static void ConfigureDependenciesRepository(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddDbContext<PgContext>(
                options => options.UseNpgsql(configuration.GetConnectionString("Default")).UseLowerCaseNamingConvention()
            );
        }
    }
}
