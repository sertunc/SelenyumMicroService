using BasketService.Data.Abstractions.Entities;
using BasketService.Data.Abstractions.Interfaces;
using SelenyumMicroService.Caching;

namespace BasketService.Data.Redis.Repositories
{
    public class BasketRepository : IBasketRepository
    {
        private readonly ICache _cache;

        public BasketRepository(ICache cache)
        {
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
        }

        public async Task<bool> DeleteBasketAsync(string buyerId)
        {
            await _cache.RemoveAsync(buyerId);
            return true;
        }

        public async Task<CustomerBasket> GetBasketAsync(string buyerId)
        {
            var item = await _cache.GetValueAsync<CustomerBasket>(buyerId);
            return item;
        }

        public IEnumerable<string> GetUsers()
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            await _cache.SetValueAsync(basket.BuyerId, basket);
            return basket;
        }
    }
}