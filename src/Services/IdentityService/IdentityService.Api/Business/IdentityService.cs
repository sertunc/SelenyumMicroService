using IdentityService.Api.BusinessAbstractions;
using IdentityService.Api.Models;
using IdentityService.Api.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using SelenyumMicroService.Shared.Dtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace IdentityService.Api.Business
{
    public class IdentityService : IIdentityService
    {
        // TODO: "In a real-world scenario, Issuer, Audience, Scope, and Resource should be correctly specified and we just use core identity not identityServer4."
        private const string issuer = "selenyum.com";   // "Issuer" is a piece of information in a JWT that specifies who created the JWT.

        private const string audience = "selenyum.com"; // "Audience" is a piece of information in a JWT that specifies which resources or services the JWT is intended for.
        private const string tokenSecret = "SelenyumMicroServiceSuperSecureKey";
        private static readonly TimeSpan tokenLifetime = TimeSpan.FromDays(1);

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public IdentityService(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _roleManager = roleManager ?? throw new ArgumentNullException(nameof(roleManager));
        }

        public async Task<Response<LoginResponseModel>> LoginAsync(LoginRequestModel loginRequestModel)
        {
            var result = await _signInManager.PasswordSignInAsync(loginRequestModel.Username, loginRequestModel.Password, false, lockoutOnFailure: false);

            //TODO: raise user login success or fail event maybe for notfication | UserLoginSuccessEvent | UserLoginFailureEvent
            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(loginRequestModel.Username);
                var roles = await _userManager.GetRolesAsync(user!);

                if (roles.Count == 0)
                {
                    return Response<LoginResponseModel>.Fail("User has no roles");
                }

                var claims = new List<Claim>
                {
                    new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new(JwtRegisteredClaimNames.Sub, user.UserName),
                    new(JwtRegisteredClaimNames.Email, user.Email),
                };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.UTF8.GetBytes(tokenSecret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.Add(tokenLifetime),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                var encodedToken = tokenHandler.WriteToken(token);

                return Response<LoginResponseModel>.Success(new LoginResponseModel(loginRequestModel.Username, encodedToken), 200);
            }
            else
            {
                return Response<LoginResponseModel>.Fail("Invalid username or password");
            }
        }

        public async Task<Response<bool>> SignupAsync(SignupRequestModel signupRequestModel)
        {
            var errorList = new List<string>();
            var user = new ApplicationUser { UserName = signupRequestModel.Username, Email = signupRequestModel.Email, Name = signupRequestModel.Name, Surname = signupRequestModel.Surname };
            var result = await _userManager.CreateAsync(user, signupRequestModel.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                await _userManager.AddToRoleAsync(user, nameof(UserRole.Customer));

                return Response<bool>.Success(true, 200);
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    errorList.Add(error.Description);
                }

                return Response<bool>.Fail(errorList);
            }
        }
    }
}