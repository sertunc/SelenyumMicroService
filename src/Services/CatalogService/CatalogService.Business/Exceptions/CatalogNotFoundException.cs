namespace CatalogService.Business.Exceptions
{
    public class CatalogNotFoundException : Exception
    {
        public CatalogNotFoundException(string message) : base(message)
        {
        }
    }
}