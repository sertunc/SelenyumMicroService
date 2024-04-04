namespace CatalogService.Business.Abstractions.Models
{
    public record CatalogItemViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public decimal Price { get; init; }
        public string PictureUri { get; init; }
        public string CatalogType { get; init; }
    }
}