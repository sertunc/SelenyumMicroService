using PaymentService.Messages.Events;

namespace PaymentService.Messages.Producers.Abstractions.Interfaces
{
    public interface IPaymentPublishes
    {
        Task PublishPaymentSucceededAsync(OrderPaymentSucceeded orderPaymentSucceeded);

        Task PublishPaymentFailedAsync(OrderPaymentFailed orderPaymentFailed);
    }
}