namespace CatalogService.Business.Abstractions.Models
{
    public record CatalogTypesViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
    }
}