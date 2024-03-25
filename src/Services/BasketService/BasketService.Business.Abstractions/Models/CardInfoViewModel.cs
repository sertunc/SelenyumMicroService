namespace BasketService.Business.Abstractions.Models
{
    public record CardInfoViewModel(string CardNumber, string CardHolderName, string CardExpiration, string CardSecurityCode, string CardType);
}