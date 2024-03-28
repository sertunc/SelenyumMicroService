using Microsoft.Extensions.DependencyInjection;
using PaymentService.Business.Abstractions;
using PaymentService.Business.Business;

namespace PaymentService.Business.Extensions
{
    public static class ConfigureBusiness
    {
        public static void AddBusiness(this IServiceCollection services)
        {
            services.AddScoped<IPaymentBusiness, PaymentBusiness>();
        }
    }
}