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
        [Route("types")]
        public async Task<IActionResult> CatalogTypes()
        {
            _logger.LogDebug("Getting catalog types");

            var result = await _catalogBusiness.GetCatalogTypesAsync();

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Route("itemsbytype")]
        public async Task<IActionResult> ItemByCatalogType([FromQuery] int catalogTypeId, [FromQuery] int pageIndex = 0)
        {
            _logger.LogDebug("Getting catlog by catalog type");

            var result = await _catalogBusiness.GetCatalogItemByCatalogTypeAsync(catalogTypeId, pageSize: 2, pageIndex);

            return StatusCode(result.StatusCode, result);
        }

        [HttpGet]
        [Route("items/{id}")]
        public async Task<IActionResult> ItemById(int id)
        {
            _logger.LogDebug("Getting catalog item by id={0}", id);

            var result = await _catalogBusiness.GetCatalogItemAsync(id);

            return StatusCode(200, result);
        }

        [HttpGet]
        [Route("items")]
        public async Task<IActionResult> Items([FromQuery] int pageIndex = 0)
        {
            _logger.LogDebug("Getting catalog items");

            var result = await _catalogBusiness.GetCatalogItemsAsync(pageSize: 5, pageIndex);

            return StatusCode(result.StatusCode, result);
        }
    }
}