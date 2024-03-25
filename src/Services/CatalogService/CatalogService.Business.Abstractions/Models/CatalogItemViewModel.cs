namespace CatalogService.Business.Abstractions.Models
{
    public record CatalogItemViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public decimal Price { get; init; }
    }
}