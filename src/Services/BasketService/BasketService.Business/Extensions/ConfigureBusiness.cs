using BasketService.Business.Abstractions.Interfaces;
using BasketService.Business.Business;
using Microsoft.Extensions.DependencyInjection;

namespace BasketService.Business.Extensions
{
    public static class ConfigureBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IBasketBusiness, BasketBusiness>();
            services.AddTransient<IIdentityService, IdentityService>();
        }
    }
}