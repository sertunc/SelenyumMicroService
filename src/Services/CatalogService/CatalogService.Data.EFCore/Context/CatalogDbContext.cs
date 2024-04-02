using CatalogService.Data.Abstractions.Entities;
using CatalogService.Data.EFCore.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.EFCore.Context
{
    public class CatalogDbContext : DbContext
    {
        public const string DEFAULT_SCHEMA = "catalog";

        public CatalogDbContext(DbContextOptions<CatalogDbContext> options) : base(options)
        {
        }

        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CatalogType> CatalogTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CatalogItemEntityTypeConfiguration());
            builder.ApplyConfiguration(new CatalogTypeEntityTypeConfiguration());
        }
    }
}