using CatalogService.Api.Domain;
using CatalogService.Api.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastruture.EntityConfigurations
{
    public class CatalogBrandEntityTypeConfiguration : IEntityTypeConfiguration<CatalogBrand>
    {
        public void Configure(EntityTypeBuilder<CatalogBrand> builder)
        {
            builder.ToTable("CatalogBrand", CatalogDbContext.DEFAULT_SCHEMA);

            builder.HasKey(b => b.Id);

            builder.Property(b => b.Id)
                .UseHiLo("catalog_brand_hilo")
                .IsRequired();

            builder.Property(b => b.Brand)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}