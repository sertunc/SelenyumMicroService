namespace CatalogService.Business.Abstractions.Models
{
    public record CatalogBrandsViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}