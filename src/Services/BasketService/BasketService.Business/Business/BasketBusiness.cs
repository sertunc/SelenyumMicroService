using AutoMapper;
using BasketService.Business.Abstractions;
using BasketService.Common.ViewModels;
using BasketService.Data.Abstractions.Interfaces;
using BasketService.Data.Models;
using BasketService.Messages.Events;
using BasketService.Messages.Producers.Abstractions;
using PaymentService.Client.Abstractions;
using PaymentService.Common.ViewModels;
using SelenyumMicroService.Shared.Dtos;
using System.Net;

namespace BasketService.Business.Business
{
    public class BasketBusiness : IBasketBusiness
    {
        private readonly IMapper _mapper;
        private readonly IBasketRepository _basketRepository;
        private readonly IBasketPublishes _basketPublisher;
        private readonly IIdentityService _identityService;
        private readonly IPaymentServiceClient _paymentServiceClient;

        public BasketBusiness(
            IMapper mapper,
            IBasketRepository basketRepository,
            IBasketPublishes basketPublisher,
            IIdentityService identityService,
            IPaymentServiceClient paymentServiceClient)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _basketRepository = basketRepository ?? throw new ArgumentNullException(nameof(basketRepository));
            _basketPublisher = basketPublisher ?? throw new ArgumentNullException(nameof(basketPublisher));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _paymentServiceClient = paymentServiceClient ?? throw new ArgumentNullException(nameof(paymentServiceClient));
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

        public async Task<Response<bool>> CheckoutBasketAsync(BasketCheckoutViewModel basketCheckoutViewModel)
        {
            var customerBasket = await _basketRepository.GetBasketAsync(basketCheckoutViewModel.BuyerId);

            if (customerBasket == null)
            {
                return Response<bool>.Fail("Basket is null");
            }

            var buyerId = customerBasket.BuyerId; //The parameters retrieved from the database are trusted over those received from the user.
            var shippingAddress = _mapper.Map<Address>(basketCheckoutViewModel.ShippingAddress);
            var cardInfo = _mapper.Map<CardInfo>(basketCheckoutViewModel.CardInfo);

            var paymentCardInfo = new PaymentService.Common.ViewModels.CardInfoViewModel(cardInfo.CardNumber, cardInfo.CardHolderName, cardInfo.CardExpiration, cardInfo.CardSecurityCode, cardInfo.CardType);
            var paymentViewModel = new PaymentViewModel(paymentCardInfo, buyerId, customerBasket.Items.Sum(x => x.UnitPrice * x.Quantity));

            var receivePaymentResult = await _paymentServiceClient.ReceivePaymentAsync(paymentViewModel);

            if (receivePaymentResult.IsSuccessful)
            {
                //TODO: dont take items price from frontend. Take it from database on the gateway
                OrderCreated orderCreated = new(buyerId,
                                            new CustomerBasket(buyerId, customerBasket.Items),
                                            new BasketCheckout(shippingAddress, cardInfo, buyerId));

                await _basketPublisher.PublishOrderCreatedAsync(orderCreated);

                return Response<bool>.Success(true);
            }
            else
            {
                return Response<bool>.Fail(receivePaymentResult.Errors[0]);
            }
        }

        public async Task<Response<bool>> DeleteBasketAsync(string buyerId)
        {
            var basket = await _basketRepository.GetBasketAsync(buyerId);

            if (basket == null)
            {
                return Response<bool>.Fail("Basket not found", (int)HttpStatusCode.NotFound);
            }

            var result = await _basketRepository.DeleteBasketAsync(buyerId);

            if (!result)
                return Response<bool>.Fail("Basket not deleted", (int)HttpStatusCode.InternalServerError);
            else
                return Response<bool>.Success(result);
        }
    }
}