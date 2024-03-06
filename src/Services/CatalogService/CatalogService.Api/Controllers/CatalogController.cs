using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        public CatalogController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok("App is running...");
        }
    }
}