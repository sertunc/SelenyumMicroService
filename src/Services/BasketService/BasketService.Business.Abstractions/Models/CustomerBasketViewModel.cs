using System.Collections.Generic;

namespace BasketService.Business.Abstractions.Models
{
    public record CustomerBasketViewModel(string BuyerId, List<BasketItemViewModel> Items);
}