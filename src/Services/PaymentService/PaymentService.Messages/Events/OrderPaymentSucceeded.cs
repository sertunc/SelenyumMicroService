namespace PaymentService.Messages.Events
{
    public record OrderPaymentSucceeded
    {
        public int OrderId { get; init; }
        public int PaymentId { get; init; }

        public OrderPaymentSucceeded(int orderId, int paymentId)
        {
            OrderId = orderId;
            PaymentId = paymentId;
        }
    }
}