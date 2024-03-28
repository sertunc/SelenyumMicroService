namespace OrderService.Domain.AggregateModels.OrderAggregate
{
    public record Address
    {
        public string Province { get; init; }

        public string District { get; init; }

        public string Street { get; init; }

        public string ZipCode { get; init; }

        public string Line { get; init; }

        public Address(string province, string district, string street, string zipCode, string line)
        {
            Province = province;
            District = district;
            Street = street;
            ZipCode = zipCode;
            Line = line;
        }
    }
}