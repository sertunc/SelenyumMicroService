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

        public async Task<IEnumerable<CatalogType>> GetCatalogTypesAsync()
        {
            return await dbContext.CatalogTypes.AsNoTracking().ToListAsync();
        }

        public async Task<int> GetCatalogItemByCatalogTypeTotalAsync(int catalogTypeId)
        {
            return await dbContext.CatalogItems.AsNoTracking().CountAsync(x => x.CatalogTypeId == catalogTypeId);
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemByCatalogTypeAsync(int catalogTypeId, int pageSize, int pageIndex)
        {
            return await dbContext.CatalogItems
                .AsNoTracking()
                .Where(x => x.CatalogTypeId == catalogTypeId)
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<CatalogItem> GetCatalogItemAsync(int id)
        {
            return await dbContext.CatalogItems
                                  .AsNoTracking()
                                  .Include(x => x.CatalogType)
                                  .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> GetCatalogItemsTotalAsync()
        {
            return await dbContext.CatalogItems.AsNoTracking().CountAsync();
        }

        public async Task<IEnumerable<CatalogItem>> GetCatalogItemsAsync(int pageSize, int pageIndex)
        {
            return await dbContext.CatalogItems
                .AsNoTracking()
                .Skip(pageSize * pageIndex)
                .Take(pageSize)
                .ToListAsync();
        }
    }
}