using IdentityService.Api.Context;
using IdentityService.Api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IdentityService.Api.Extensions
{
    public static class ConfigureDbContext
    {
        public static void AddDbContextConfigurations(this IServiceCollection services, ConfigurationManager config)
        {
            string? connectionString = config.GetConnectionString("ApplicationDbContext");
            ArgumentNullException.ThrowIfNull(connectionString);

            services.AddDbContext<ApplicationDbContext>(x => x.UseSqlServer(connectionString));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
              .AddDefaultTokenProviders();

            var dbContext = services.BuildServiceProvider().GetService<ApplicationDbContext>();
            var roleManager = services.BuildServiceProvider().GetService<RoleManager<IdentityRole>>();
            var userManager = services.BuildServiceProvider().GetService<UserManager<ApplicationUser>>();

            ArgumentNullException.ThrowIfNull(dbContext);
            ArgumentNullException.ThrowIfNull(roleManager);
            ArgumentNullException.ThrowIfNull(userManager);

            var isAlreadyInitialized = !dbContext.Database.EnsureCreated();

            if (!isAlreadyInitialized)
            {
                SetSeeds(roleManager, userManager);

                dbContext?.SaveChanges();
            }
        }

        private static void SetSeeds(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager)
        {
            UserRolesSeed(roleManager);

            UsersSeed(userManager);
        }

        private static void UserRolesSeed(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = Enum.GetNames(typeof(UserRole));

            foreach (var roleName in roleNames)
            {
                var roleExists = roleManager.RoleExistsAsync(roleName).Result;
                if (!roleExists)
                {
                    roleManager.CreateAsync(new IdentityRole(roleName)).Wait();
                }
            }
        }

        private static void UsersSeed(UserManager<ApplicationUser> userManager)
        {
            var adminEmail = "admin@selenyum.com";
            var adminPassword = "admin@selenyum.com";

            var adminUser = new ApplicationUser
            {
                UserName = adminEmail,
                Email = adminEmail,
                Name = "Admin",
                Surname = "Selenyum",
            };

            var user = userManager.FindByEmailAsync(adminEmail).Result;
            if (user == null)
            {
                var createPowerUser = userManager.CreateAsync(adminUser, adminPassword).Result;
                if (createPowerUser.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Admin").Wait();
                }
            }
        }
    }
}