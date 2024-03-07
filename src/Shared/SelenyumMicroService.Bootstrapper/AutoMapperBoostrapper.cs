using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace SelenyumMicroService.Bootstrapper
{
    public static class AutoMapperBoostrapper
    {
        public static void AddAutoMapper<T>(this IServiceCollection services) where T : Profile, new()
        {
            services.AddSingleton(m =>
            {
                var mapperConfig = new MapperConfiguration(mc => { mc.AddProfile(new T()); });
                return mapperConfig.CreateMapper();
            });
        }
    }
}