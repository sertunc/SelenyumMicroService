using BasketService.Business.Abstractions.Interfaces;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BasketService.Business.Business
{
    public class IdentityService : IIdentityService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public IdentityService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        }

        public string GetUserName()
        {
            var userName = _httpContextAccessor.HttpContext?.User?.FindFirst(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
            ArgumentNullException.ThrowIfNull(userName, nameof(userName));

            return userName;
        }
    }
}