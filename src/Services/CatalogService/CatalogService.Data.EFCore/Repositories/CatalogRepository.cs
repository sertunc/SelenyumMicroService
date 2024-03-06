using CatalogService.Data.Abstractions.Interfaces;
using CatalogService.Data.EFCore.Context;

namespace CatalogService.Data.EFCore.Repositories
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext dbContext;

        public CatalogRepository(CatalogDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public bool IsRunning(int id)
        {
            return dbContext.CatalogItems.Any(x => x.Id == id);
        }
    }
}