using CatalogService.Api.Domain;
using CatalogService.Api.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CatalogService.Api.Infrastruture.EntityConfigurations
{
    public class CatalogTypeEntityTypeConfiguration : IEntityTypeConfiguration<CatalogType>
    {
        public void Configure(EntityTypeBuilder<CatalogType> builder)
        {
            builder.ToTable("CatalogType", CatalogDbContext.DEFAULT_SCHEMA);

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseHiLo("catalog_type_hilo")
                .IsRequired();

            builder.Property(t => t.Type)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}