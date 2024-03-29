using PaymentService.Client;
using PaymentService.Client.Abstractions;
using SelenyumMicroService.Api.Client.Providers;
using SelenyumMicroService.Bootstrapper;
using SelenyumMicroService.RequestIdentifierProvider;

namespace BasketService.Api.Extensions
{
    public static class ConfigureHttpClients
    {
        public static void AddHttpClients(this IServiceCollection services, IConfiguration Configuration)
        {
            var gatewayAddress = Configuration["Gateway:Address"];
            ArgumentNullException.ThrowIfNull(gatewayAddress);

            services.AddScoped<IRequestIdProvider, RequestIdProvider>();

            services.AddCustomHttpClient<IPaymentServiceClient, PaymentServiceClient>(gatewayAddress);
        }
    }
}