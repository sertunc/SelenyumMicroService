using Microsoft.AspNetCore.Mvc;
using PaymentService.Business.Abstractions;
using PaymentService.Common.ViewModels;

namespace PaymentService.Api.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly ILogger<PaymentController> _logger;
        private readonly IPaymentBusiness _paymentBusiness;

        public PaymentController(ILogger<PaymentController> logger, IPaymentBusiness paymentBusiness)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _paymentBusiness = paymentBusiness ?? throw new ArgumentNullException(nameof(paymentBusiness));
        }

        [HttpPost]
        public async Task<IActionResult> ReceivePaymentAsync(PaymentViewModel payViewModel)
        {
            _logger.LogDebug("PaymentController- ReceivePaymentAsync with {buyerId}", payViewModel.BuyerId);

            var result = await _paymentBusiness.ReceivePaymentAsync(payViewModel);

            return StatusCode(result.StatusCode, result);
        }
    }
}