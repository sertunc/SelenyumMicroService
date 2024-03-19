using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace SelenyumMicroService.ServiceDiscovery.Consul
{
    public static class ConfigureServiceDiscovery
    {
        public static IServiceCollection AddConsul(this IServiceCollection services, ConsulSettings consulSettings)
        {
            services.AddSingleton<IConsulClient, ConsulClient>(p => new ConsulClient(consulConfig =>
            {
                ArgumentNullException.ThrowIfNull(consulSettings.ConsulAddress);

                consulConfig.Address = new Uri(consulSettings.ConsulAddress);
            }));

            return services;
        }

        public static IApplicationBuilder UseConsul(this IApplicationBuilder app, IHostApplicationLifetime lifetime, ConsulSettings consulSettings)
        {
            ArgumentNullException.ThrowIfNull(consulSettings.ServiceId);
            ArgumentNullException.ThrowIfNull(consulSettings.ServiceName);
            ArgumentNullException.ThrowIfNull(consulSettings.ServiceHostUrl);

            var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();

            var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
            var logger = loggingFactory.CreateLogger<IApplicationBuilder>();

            //Register service with consul
            var registration = new AgentServiceRegistration()
            {
                ID = $"{consulSettings.ServiceId}_{new Uri(consulSettings.ServiceHostUrl).Port}",
                Name = consulSettings.ServiceName,
                Address = new Uri(consulSettings.ServiceHostUrl).Host,
                Port = new Uri(consulSettings.ServiceHostUrl).Port,
                Tags = consulSettings.Tags,
            };

            logger.LogInformation("Registering with Consul");
            consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            consulClient.Agent.ServiceRegister(registration).Wait();

            lifetime.ApplicationStopping.Register(() =>
            {
                logger.LogInformation("Deregistering from Consul");
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();
            });

            return app;
        }
    }
}