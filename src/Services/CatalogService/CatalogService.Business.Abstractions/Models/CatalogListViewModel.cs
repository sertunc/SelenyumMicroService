namespace CatalogService.Business.Abstractions.Models
{
    //if desired, the interface of this model can be implemented
    //and a concrete class can be created in the CatalogService.Business layer.
    public record CatalogListViewModel
    {
        public string Id { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public string Price { get; init; }
        public string PictureUri { get; init; }
    }
}