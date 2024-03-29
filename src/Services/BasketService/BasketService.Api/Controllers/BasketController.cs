using BasketService.Business.Abstractions;
using BasketService.Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BasketService.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BasketController : ControllerBase
    {
        private readonly ILogger<BasketController> _logger;
        private readonly IBasketBusiness _basketBusiness;

        public BasketController(ILogger<BasketController> logger, IBasketBusiness basketBusiness)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _basketBusiness = basketBusiness ?? throw new ArgumentNullException(nameof(basketBusiness));
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Basket Service is Up and Running");
        }

        [HttpGet("{buyerId}")]
        public async Task<IActionResult> GetBasketByIdAsync(string buyerId)
        {
            _logger.LogDebug("Getting basket with {buyerId}", buyerId);

            var result = await _basketBusiness.GetBasketByIdAsync(buyerId);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("update")]
        public async Task<IActionResult> UpdateBasketAsync(CustomerBasketViewModel basketViewModel)
        {
            _logger.LogDebug("Updateing basket with {buyerId}", basketViewModel.BuyerId);

            var result = await _basketBusiness.UpdateBasketAsync(basketViewModel);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("additem")]
        public async Task<IActionResult> AddItemToBasketAsync(BasketItemViewModel basketItemViewModel)
        {
            _logger.LogDebug("Adding basket item with {Id}", basketItemViewModel.Id);

            var result = await _basketBusiness.AddItemToBasketAsync(basketItemViewModel);

            return StatusCode(result.StatusCode, result);
        }

        [HttpPost("checkout")]
        public async Task<IActionResult> CheckoutBasketAsync(BasketCheckoutViewModel basketCheckoutViewModel)
        {
            _logger.LogDebug("Checkouting basket with {buyerId}", basketCheckoutViewModel.BuyerId);

            var result = await _basketBusiness.CheckoutBasketAsync(basketCheckoutViewModel);

            return StatusCode(result.StatusCode, result);
        }

        [HttpDelete("{buyerId}")]
        public async Task<IActionResult> DeleteBasketAsync(string buyerId)
        {
            _logger.LogDebug("Deleting basket with {buyerId}", buyerId);

            var result = await _basketBusiness.DeleteBasketAsync(buyerId);

            return StatusCode(result.StatusCode, result);
        }
    }
}