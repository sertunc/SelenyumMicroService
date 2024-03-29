using AutoMapper;
using BasketService.Common.ViewModels;
using BasketService.Data.Models;

namespace BasketService.Business.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddressViewModel, Address>().ReverseMap();

            CreateMap<BasketCheckoutViewModel, BasketCheckout>().ReverseMap();

            CreateMap<BasketItemViewModel, BasketItem>().ReverseMap();

            CreateMap<CardInfoViewModel, CardInfo>().ReverseMap();

            CreateMap<CustomerBasketViewModel, CustomerBasket>().ReverseMap();
        }
    }
}