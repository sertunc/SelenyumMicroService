﻿using CatalogService.Data.Abstractions.Entities;
using CatalogService.Data.Abstractions.Interfaces;
using CatalogService.Data.EFCore.Context;
using CatalogService.Data.EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CatalogService.Data.EFCore.Extensions
{
    public static class ConfigureDbContext
    {
        public static void AddDbContextConfigurations(this IServiceCollection services, ConfigurationManager config)
        {
            string? connectionString = config.GetConnectionString("CatalogDbContext");
            ArgumentNullException.ThrowIfNull(connectionString);

            services.AddDbContext<CatalogDbContext>(x => x.UseSqlServer(connectionString));

            var dbContext = services.BuildServiceProvider().GetService<CatalogDbContext>();

            var isAlreadyInitialized = !dbContext.Database.EnsureCreated();

            if (!isAlreadyInitialized)
            {
                SetSeeds(dbContext);

                dbContext.SaveChanges();
            }
        }

        public static void AddDbContextRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICatalogRepository, CatalogRepository>();
        }

        private static void SetSeeds(CatalogDbContext catalogDbContext)
        {
            CatalogTypesSeed(catalogDbContext);

            ScheduleTypeSeed(catalogDbContext);
        }

        private static void CatalogTypesSeed(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.CatalogTypes.AddRange(
                new CatalogType { Id = 1, Type = "Mug", IconName = "CoffeeIcon" },
                new CatalogType { Id = 2, Type = "T-Shirt", IconName = "ImageIcon" },
                new CatalogType { Id = 3, Type = "Sheet", IconName = "NoteIcon" },
                new CatalogType { Id = 4, Type = "USB Memory Stick", IconName = "SdCardIcon" });
        }

        private static void ScheduleTypeSeed(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.CatalogItems.AddRange(
                new CatalogItem { Id = 1, Name = ".NET Bot Black Hoodie", Description = ".NET Bot Black Hoodie and more", Price = 19.50M, PictureFileName = "1.png", PictureUri = "http://externalcatalogbaseurltobereplaced/api/pic/1", CatalogTypeId = 2 });
        }
    }
}