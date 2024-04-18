using IdentityService.Api.BusinessAbstractions;
using IdentityService.Api.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controller
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IIdentityService _identityService;

        public AuthController(IIdentityService identityService)
        {
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestModel loginRequestModel)
        {
            var result = await _identityService.LoginAsync(loginRequestModel);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequestModel signupRequestModel)
        {
            var result = await _identityService.SignupAsync(signupRequestModel);
            return Ok(result);
        }

        [HttpGet("userprofile")]
        public async Task<IActionResult> UserProfile()
        {
            var result = await _identityService.UserProfileAsync();
            return Ok(result);
        }
    }
}