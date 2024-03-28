using PaymentService.Business.Abstractions;
using PaymentService.Data.Models;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Business.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        public Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel)
        {
            var orderId = new Random().Next(0, 10).ToString();
            var paymentId = new Random().Next(0, 10).ToString();
            var randomResult = new Random().Next(0, 10) % 2 == 0;
            var paymentResult = new PaymentResultViewModel(orderId, paymentId);

            if (randomResult)
                return Task.FromResult(Response<PaymentResultViewModel>.Success(paymentResult));
            else
                return Task.FromResult(Response<PaymentResultViewModel>.Fail("Payment failed", paymentResult));
        }
    }
}