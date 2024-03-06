﻿using CatalogService.Api.Domain;
using CatalogService.Api.Infrastruture.Context;

namespace CatalogService.Api.Extensions
{
    public static class ConfigureDbContext
    {
        public static void AddDbContextSeeds(this IServiceCollection services)
        {
            var dbContext = services.BuildServiceProvider().GetService<CatalogDbContext>();

            var isAlreadyInitialized = !dbContext.Database.EnsureCreated();

            if (!isAlreadyInitialized)
            {
                SetSeeds(dbContext);

                dbContext.SaveChanges();
            }
        }

        private static void SetSeeds(CatalogDbContext catalogDbContext)
        {
            CatalogBrandsSeed(catalogDbContext);

            CatalogTypesSeed(catalogDbContext);

            ScheduleTypeSeed(catalogDbContext);
        }

        private static void CatalogBrandsSeed(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.CatalogBrands.AddRange(
                new CatalogBrand { Id = 1, Brand = "Azure" },
                new CatalogBrand { Id = 2, Brand = ".NET" },
                new CatalogBrand { Id = 3, Brand = "Visual Studio" },
                new CatalogBrand { Id = 4, Brand = "SQL Server" },
                new CatalogBrand { Id = 5, Brand = "Other" },
                new CatalogBrand { Id = 6, Brand = "CatalogBrandTestOne" },
                new CatalogBrand { Id = 7, Brand = "CatalogBrandTestTwo" });
        }

        private static void CatalogTypesSeed(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.CatalogTypes.AddRange(
                new CatalogType { Id = 1, Type = "Mug" },
                new CatalogType { Id = 2, Type = "T-Shirt" },
                new CatalogType { Id = 3, Type = "Sheet" },
                new CatalogType { Id = 4, Type = "USB Memory Stick" },
                new CatalogType { Id = 5, Type = "CatalogTypeTestOne" },
                new CatalogType { Id = 6, Type = "CatalogTypeTestTwo" });
        }

        private static void ScheduleTypeSeed(CatalogDbContext catalogDbContext)
        {
            catalogDbContext.CatalogItems.AddRange(
                new CatalogItem { Id = 1, Name = ".NET Bot Black Hoodie", Description = ".NET Bot Black Hoodie and more", Price = 19.50M, PictureFileName = "1.png", PictureUri = "http://externalcatalogbaseurltobereplaced/api/pic/1", CatalogTypeId = 2, CatalogBrandId = 2 });
        }
    }
}