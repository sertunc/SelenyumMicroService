namespace BasketService.Data.Abstractions.ValueObjects
{
    public record Address(string City, string Street, string State, string Country, string ZipCode);
}