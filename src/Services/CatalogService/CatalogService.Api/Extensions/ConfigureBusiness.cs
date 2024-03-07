using CatalogService.Business.Abstractions.Interfaces;
using CatalogService.Business.Business;

namespace CatalogService.Api.Extensions
{
    public static class ConfigureBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICatalogBusiness, CatalogBusiness>();
        }
    }
}