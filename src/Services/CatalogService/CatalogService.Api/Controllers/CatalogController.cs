using CatalogService.Data.Abstractions.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ILogger<CatalogController> _logger;
        private readonly ICatalogRepository _repository;

        public CatalogController(
            ILogger<CatalogController> logger,
            ICatalogRepository repository)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = _repository.IsRunning(1);
            return Ok($"App is running... {result}");
        }
    }
}