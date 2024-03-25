namespace BasketService.Data.Abstractions.ValueObjects
{
    public record CardInfo(string CardNumber, string CardHolderName, string CardExpiration, string CardSecurityCode, string CardType);
}