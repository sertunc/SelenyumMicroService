using PaymentService.Business.Abstractions;
using PaymentService.Common.ViewModels;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Business.Business
{
    public class PaymentBusiness : IPaymentBusiness
    {
        private static readonly string[] _dummyFailMessages = new string[]
        {
            "Bank connection could not be established.",
            "Invalid card information.",
            "Insufficient balance.",
            "System error, please try again later."
        };

        public Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel)
        {
            var orderId = new Random().Next(0, 10).ToString();
            var paymentId = new Random().Next(0, 10).ToString();
            var randomResult = new Random().Next(0, 10) % 2 == 0;
            var paymentResult = new PaymentResultViewModel(orderId, paymentId);

            if (randomResult)
                return Task.FromResult(Response<PaymentResultViewModel>.Success(paymentResult));
            else
            {
                var message = _dummyFailMessages[new Random().Next(0, _dummyFailMessages.Length)];
                return Task.FromResult(Response<PaymentResultViewModel>.Fail(message, paymentResult));
            }
        }
    }
}