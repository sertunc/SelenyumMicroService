using BasketService.Common.ViewModels;
using SelenyumMicroService.Shared.Dtos;

namespace BasketService.Business.Abstractions
{
    public interface IBasketBusiness
    {
        Task<Response<CustomerBasketViewModel>> GetBasketByIdAsync(string buyerId);

        Task<Response<CustomerBasketViewModel>> UpdateBasketAsync(CustomerBasketViewModel customerBasketViewModel);

        Task<Response<bool>> AddItemToBasketAsync(BasketItemViewModel basketItemViewModel);

        Task<Response<bool>> CheckoutBasketAsync(BasketCheckoutViewModel basketCheckoutViewModel);

        Task<Response<bool>> DeleteBasketAsync(string buyerId);
    }
}