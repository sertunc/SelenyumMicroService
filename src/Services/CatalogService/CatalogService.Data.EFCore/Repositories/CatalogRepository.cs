using CatalogService.Data.Abstractions.Entities;
using CatalogService.Data.Abstractions.Interfaces;
using CatalogService.Data.EFCore.Context;
using Microsoft.EntityFrameworkCore;

namespace CatalogService.Data.EFCore.Repositories
{
    //if desired, a generic repository can be implemented.
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext dbContext;

        public CatalogRepository(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<CatalogItem> GetCatalogItemAsync(int id)
        {
            return await dbContext.CatalogItems.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCatalogItemsTotalAsync()
        {
            return await dbContext.CatalogItems.CountAsync();
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(int pageSize, int pageIndex)
        {
            return await dbContext.CatalogItems
                .OrderBy(x => x.Name)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}