using CatalogService.Business.Abstractions.Interfaces;
using CatalogService.Business.Business;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Business.Extensions
{
    public static class ConfigureBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<ICatalogBusiness, CatalogBusiness>();
        }
    }
}