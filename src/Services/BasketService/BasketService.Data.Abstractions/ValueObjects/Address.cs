namespace BasketService.Data.Abstractions.ValueObjects
{
    public class Address
    {
        public string City { get; init; }
        public string Street { get; init; }
        public string State { get; init; }
        public string Country { get; init; }
        public string ZipCode { get; init; }

        public Address(string city, string street, string state, string country, string zipCode)
        {
            City = city;
            Street = street;
            State = state;
            Country = country;
            ZipCode = zipCode;
        }
    }
}