using PaymentService.Common.ViewModels;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Business.Abstractions
{
    public interface IPaymentBusiness
    {
        Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel);
    }
}