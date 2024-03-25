namespace SelenyumMicroService.Shared.Dtos
{
    public record PaginatedItemsViewModel<TEntity>(int pageIndex, int pageSize, long count, IEnumerable<TEntity> data);
}