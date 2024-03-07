using CatalogService.Business.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogBusiness _catalogBusiness;

        public CatalogController(
            ILogger<CatalogController> logger,
            ICatalogBusiness catalogBusiness)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _catalogBusiness = catalogBusiness ?? throw new ArgumentNullException(nameof(catalogBusiness));
        }

        [HttpGet]
        [Route("Items/{id}")]
        public async Task<IActionResult> ItemById(int id)
        {
            _logger.LogInformation("Getting catalog item by id");

            var result = await _catalogBusiness.GetCatalogItemAsync(id);

            return Ok(result);
        }

        [HttpGet]
        [Route("Items")]
        public async Task<IActionResult> Items([FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
        {
            _logger.LogInformation("Getting catalog items");

            var result = await _catalogBusiness.GetCatalogItemsAsync(pageSize, pageIndex);

            return Ok(result);
        }
    }
}