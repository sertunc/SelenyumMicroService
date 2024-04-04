using CatalogService.Data.Abstractions.Entities;

namespace CatalogService.Data.Abstractions.Interfaces
{
    public interface ICatalogRepository
    {
        Task<IEnumerable<CatalogType>> GetCatalogTypesAsync();

        Task<int> GetCatalogItemByCatalogTypeTotalAsync(int catalogTypeId);

        Task<IEnumerable<CatalogItem>> GetCatalogItemByCatalogTypeAsync(int catalogTypeId, int pageSize, int pageIndex);

        Task<CatalogItem> GetCatalogItemAsync(int id);

        Task<int> GetCatalogItemsTotalAsync();

        Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(int pageSize, int pageIndex);
    }
}