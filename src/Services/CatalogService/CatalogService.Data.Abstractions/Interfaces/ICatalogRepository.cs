namespace CatalogService.Data.Abstractions.Interfaces
{
    public interface ICatalogRepository
    {
        bool IsRunning(int id);
    }
}