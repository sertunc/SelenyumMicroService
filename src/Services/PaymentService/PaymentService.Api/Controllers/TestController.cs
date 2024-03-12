using Microsoft.AspNetCore.Mvc;
using PaymentService.Messages.Events;
using PaymentService.Messages.Producers.Abstractions.Interfaces;

namespace PaymentService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogger<TestController> _logger;
        private readonly IPaymentPublishes _paymentPublishes;

        public TestController(ILogger<TestController> logger, IPaymentPublishes paymentPublishes)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _paymentPublishes = paymentPublishes ?? throw new ArgumentNullException(nameof(paymentPublishes));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await _paymentPublishes.PublishPaymentSucceededAsync(new OrderPaymentSucceeded(1598753, 2810727));

            return Ok();
        }
    }
}