namespace PaymentService.Messages.Events
{
    public record OrderPaymentFailed
    {
        public int OrderId { get; init; }
        public string Error { get; init; }

        public OrderPaymentFailed(int orderId, string error)
        {
            OrderId = orderId;
            Error = error;
        }
    }
}