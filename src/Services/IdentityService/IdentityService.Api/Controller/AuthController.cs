using IdentityService.Api.BusinessAbstractions;
using IdentityService.Api.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            var result = await _identityService.LoginAsync(loginRequestModel);
            return Ok(result);
        }

        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequestModel signupRequestModel)
        {
            var result = await _identityService.SignupAsync(signupRequestModel);
            return Ok(result);
        }
    }
}