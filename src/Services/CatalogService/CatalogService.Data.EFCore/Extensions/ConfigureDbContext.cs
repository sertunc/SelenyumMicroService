using CatalogService.Data.Abstractions.Entities;
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
                new CatalogItem
                {
                    Id = 1,
                    CatalogTypeId = 1,
                    Name = "Self Stirring Coffee Mug",
                    Description = "(Black) - Self Stirring Coffee Mug Stainless Steel Auto Magnetic Mug for Coffee/Tea/Hot Chocolate/Milk/Cocoa Protein (Black)",
                    Price = 81.68M,
                    PictureUri = "https://m.media-amazon.com/images/I/711mw-D-EtL.jpg",
                },
                new CatalogItem
                {
                    Id = 2,
                    CatalogTypeId = 1,
                    Name = "Aardman Wallace Mug",
                    Description = "Aardman Wallace ve Gromit Şekilli Mug - Gromit",
                    Price = 98.95M,
                    PictureUri = "https://m.media-amazon.com/images/I/61Rjq4RxetL._AC_UF1000,1000_QL80_.jpg",
                },
                new CatalogItem
                {
                    Id = 3,
                    CatalogTypeId = 1,
                    Name = "Starbucks Logo Mug",
                    Description = "Starbucks Logo Mug, 14oz",
                    Price = 38.95M,
                    PictureUri = "https://m.media-amazon.com/images/I/817X3ZGgYVL._AC_UF894,1000_QL80_.jpg",
                },
                new CatalogItem
                {
                    Id = 4,
                    CatalogTypeId = 1,
                    Name = "Ceramic Large Latte Mug",
                    Description = "Mora Ceramic Large Latte Mug Set of 4, 16oz - Microwavable, Porcelain Coffee Cups With Big Handle - Modern, Boho, Unique Style For Any Kitchen. Microwave Safe Stoneware - Assorted Neutrals",
                    Price = 32.95M,
                    PictureUri = "https://m.media-amazon.com/images/I/61vbV+u+89L._AC_UL320_.jpg",
                },
                new CatalogItem
                {
                    Id = 5,
                    CatalogTypeId = 2,
                    Name = "Gildan Men's Crew T-Shirts",
                    Description = "Gildan Men's Crew T-Shirts, Multipack, Style G1100",
                    Price = 16.80M,
                    PictureUri = "https://m.media-amazon.com/images/I/710o0VupScL._AC_SX569_.jpg",
                },
                new CatalogItem
                {
                    Id = 6,
                    CatalogTypeId = 2,
                    Name = "Comfort Colors Adult Short Sleeve Tee",
                    Description = "Comfort Colors Adult Short Sleeve Tee, Style 1717",
                    Price = 39.83M,
                    PictureUri = "https://m.media-amazon.com/images/I/61dBwIKrvFL._AC_SX569_.jpg",
                },
                new CatalogItem
                {
                    Id = 7,
                    CatalogTypeId = 2,
                    Name = "Hanes Women's Cotton T-Shirt",
                    Description = "Hanes Women's Perfect-T Short Sleeve Cotton Crewneck T-Shirt",
                    Price = 10.83M,
                    PictureUri = "https://m.media-amazon.com/images/I/813X6oCL-ML._AC_SX569_.jpg",
                },
                new CatalogItem
                {
                    Id = 8,
                    CatalogTypeId = 3,
                    Name = "Microfiber 4-Piece Bed Sheet",
                    Description = "Amazon Basics Lightweight Super Soft Easy Care Microfiber 4-Piece Bed Sheet Set with 14-Inch Deep Pockets, Full, Bright White, Solid",
                    Price = 15.99M,
                    PictureUri = "https://m.media-amazon.com/images/I/618xPpCwo6L._AC_SX679_.jpg",
                },
                new CatalogItem
                {
                    Id = 9,
                    CatalogTypeId = 3,
                    Name = "Cal King Size 4 Piece Sheet Set",
                    Description = "Cal King Size 4 Piece Sheet Set - Comfy Breathable & Cooling Sheets - Hotel Luxury Bed Sheets for Women & Men - Deep Pockets, Easy-Fit, Extra Soft & Wrinkle Free Sheets - White Oeko-Tex Bed Sheet Set",
                    Price = 34.99M,
                    PictureUri = "https://m.media-amazon.com/images/I/717FfWa5e4L._AC_SY879_.jpg",
                },
                new CatalogItem
                {
                    Id = 10,
                    CatalogTypeId = 4,
                    Name = "SanDisk 64GB",
                    Description = "SanDisk 64GB 2-Pack Ultra USB 3.0 Flash Drive (2x64GB) - SDCZ48-064G-GAM462, Black",
                    Price = 16.54M,
                    PictureUri = "https://m.media-amazon.com/images/I/71jzP3WDwbL._AC_SX679_PIbundle-2,TopRight,0,0_SH20_.jpg",
                },
                new CatalogItem
                {
                    Id = 11,
                    CatalogTypeId = 4,
                    Name = "USB Flash Drive 256GB",
                    Description = "USB Flash Drive 256GB Waterproof USB Stick High Speed Memory Stick 256GB Ultra Large Storage Metal Thumb Drive with Keychain Design for Laptop Computer Tablet",
                    Price = 13.99M,
                    PictureUri = "https://m.media-amazon.com/images/I/51unjJ3DgPL._AC_SX679_.jpg",
                },
                new CatalogItem
                {
                    Id = 12,
                    CatalogTypeId = 4,
                    Name = "RAOYI 5 Pack 64GB USB Flash Drive",
                    Description = "RAOYI 5 Pack 64GB USB Flash Drive, USB 2.0 Memory Stick Thumb Drives Jump Drive Pen Drive for PC Laptop Computer - 64G Multipack",
                    Price = 22.99M,
                    PictureUri = "https://m.media-amazon.com/images/I/41rwLGJ6TIL._AC_PIbundle-5,TopRight,0,0_SH20_.jpg",
                },
                new CatalogItem
                {
                    Id = 13,
                    CatalogTypeId = 4,
                    Name = "5Pcs 8GB USB Flash Drive",
                    Description = "5Pcs 8GB USB Flash Drive USB 2.0 Flash Memory Stick Thumb Stick Pen(Five Mixed Colors: Blue Purple Rose Green Gold)",
                    Price = 11.99M,
                    PictureUri = "https://m.media-amazon.com/images/I/61LFANbLl1L._AC_SX679_.jpg",
                });
        }
    }
}