using CatalogService.Api.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Api.Infrastruture
{
    public static class InfrastructureServiceExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, ConfigurationManager config)
        {
            string? connectionString = config.GetConnectionString("CatalogDbContext");
            ArgumentNullException.ThrowIfNull(connectionString);

            services.AddDbContext<CatalogDbContext>(x => x.UseSqlServer(connectionString));
            SeedData.AddDbContextSeeds(services);
        }
    }
}