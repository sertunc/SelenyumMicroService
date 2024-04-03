namespace CatalogService.Business.Abstractions.Models
{
    public record CatalogTypesViewModel
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string IconName { get; init; }
    }
}