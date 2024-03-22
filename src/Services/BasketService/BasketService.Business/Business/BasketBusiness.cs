using AutoMapper;
using BasketService.Business.Abstractions.Interfaces;
using BasketService.Business.Abstractions.Models;
using BasketService.Data.Abstractions.Entities;
using BasketService.Data.Abstractions.Interfaces;
using SelenyumMicroService.Shared.Dtos;
using System.Net;

namespace BasketService.Business.Business
{
    public class BasketBusiness : IBasketBusiness
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IIdentityService _identityService;

        public BasketBusiness(IMapper mapper, IBasketRepository basketRepository, IIdentityService identityService)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        public async Task<Response<CustomerBasketViewModel>> GetBasketByIdAsync(string buyerId)
        {
            var basket = await _basketRepository.GetBasketAsync(buyerId);

            var result = _mapper.Map<CustomerBasketViewModel>(basket);

            if (result == null)
                return Response<CustomerBasketViewModel>.Fail("Basket not found", (int)HttpStatusCode.NotFound);
            else
                return Response<CustomerBasketViewModel>.Success(result);
        }

        public async Task<Response<CustomerBasketViewModel>> UpdateBasketAsync(CustomerBasketViewModel customerBasketViewModel)
        {
            var customerBasket = _mapper.Map<CustomerBasket>(customerBasketViewModel);

            var result = await _basketRepository.UpdateBasketAsync(customerBasket);

            return Response<CustomerBasketViewModel>.Success(_mapper.Map<CustomerBasketViewModel>(result));
        }

        public async Task<Response<bool>> AddItemToBasketAsync(BasketItemViewModel basketItemViewModel)
        {
            var userId = _identityService.GetUserName();

            var basket = await _basketRepository.GetBasketAsync(userId);

            if (basket == null)
            {
                basket = new CustomerBasket(userId, new List<BasketItem>());
            }

            basket.Items.Add(_mapper.Map<BasketItem>(basketItemViewModel));

            await _basketRepository.UpdateBasketAsync(basket);

            return Response<bool>.Success(true);
        }

        public Task<Response<bool>> CheckoutBasketAsync(BasketCheckoutViewModel basketCheckoutViewModel)
        {
            var userId = basketCheckoutViewModel.BuyerId;

            var basket = _mapper.Map<BasketCheckout>(basketCheckoutViewModel);

            if (basket == null)
            {
                return Task.FromResult(Response<bool>.Fail("Basket is null"));
            }

            var userName = _identityService.GetUserName();

            //TODO: rise event

            return Task.FromResult(Response<bool>.Success(true));
        }
    }
}