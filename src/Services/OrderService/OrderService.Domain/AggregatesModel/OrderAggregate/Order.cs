using OrderService.Domain.AggregatesModel.BuyerAggregate;
using OrderService.Domain.Events;
using OrderService.Domain.SeedWork;

namespace OrderService.Domain.AggregatesModel.OrderAggregate;

public class Order : BaseEntity, IAggregateRoot
{
    public DateTime OrderDate { get; private set; }
    public int Quantity { get; private set; }
    public string Description { get; private set; }
    public Guid BuyerId { get; private set; }
    public Buyer Buyer { get; private set; }
    public Address Address { get; private set; }
    public OrderStatus OrderStatus { get; private set; }
    public IReadOnlyCollection<OrderItem> OrderItems => _orderItems;
    public Guid PaymentMethodId { get; private set; }

    private int _orderStatusId;
    private readonly List<OrderItem> _orderItems;

    protected Order()
    {
        Id = Guid.NewGuid();
        _orderItems = new List<OrderItem>();
    }

    public Order(string userName, Address address, int cardTypeId, string cardNumber, string cardSecurityNumber,
            string cardHolderName, DateTime cardExpiration, Guid buyerId, Guid paymentMethodId) : this()
    {
        BuyerId = buyerId;
        _orderStatusId = OrderStatus.Submitted.Id;
        OrderDate = DateTime.UtcNow;
        Address = address;
        PaymentMethodId = paymentMethodId;

        AddOrderStartedDomainEvent(userName, cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);
    }

    public void AddOrderItem(int productId, string productName, decimal unitPrice, decimal discount, string pictureUrl, int units = 1)
    {
        //add validated new order item

        var orderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
        _orderItems.Add(orderItem);
    }

    private void AddOrderStartedDomainEvent(string userName, int cardTypeId, string cardNumber,
            string cardSecurityNumber, string cardHolderName, DateTime cardExpiration)
    {
        var orderStartedDomainEvent = new OrderStartedDomainEvent(this, userName, cardTypeId,
                                                                    cardNumber, cardSecurityNumber,
                                                                    cardHolderName, cardExpiration);

        this.AddDomainEvent(orderStartedDomainEvent);
    }
}