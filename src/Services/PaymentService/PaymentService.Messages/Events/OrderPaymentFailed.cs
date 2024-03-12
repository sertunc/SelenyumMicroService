namespace PaymentService.Messages.Events
{
    public record OrderPaymentFailed
    {
        public int OrderId { get; }
        public string Error { get; set; }

        public OrderPaymentFailed(int orderId, string error)
        {
            OrderId = orderId;
            Error = error;
        }
    }
}