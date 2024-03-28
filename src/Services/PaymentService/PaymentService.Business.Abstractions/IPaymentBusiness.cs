using PaymentService.Data.Models;
using SelenyumMicroService.Shared.Dtos;

namespace PaymentService.Business.Abstractions
{
    public interface IPaymentBusiness
    {
        Task<Response<PaymentResultViewModel>> ReceivePaymentAsync(PaymentViewModel payViewModel);
    }
}