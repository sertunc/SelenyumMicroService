using BasketService.Data.Abstractions.Entities;

namespace BasketService.Data.Abstractions.Interfaces
{
    public interface IBasketRepository
    {
        Task<CustomerBasket> GetBasketAsync(string buyerId);

        IEnumerable<string> GetUsers();

        Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket);

        Task<bool> DeleteBasketAsync(string buyerId);
    }
}