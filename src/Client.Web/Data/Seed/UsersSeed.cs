using Microsoft.AspNetCore.Identity;
using Client.Web.Areas.Authentication;
using System.Security.Claims;

namespace Client.Web.Data.Seed
{
    public static class UsersSeed
    {
        public static void SeedUsers(this IApplicationBuilder app, UserManager<ApplicationUser> userMgr, RoleManager<IdentityRole> roleMgr)
        {
            if (userMgr.FindByEmailAsync("admin@teste.com").Result == null)
            {
                if (!(roleMgr.RoleExistsAsync("Admin").Result))
                {
                    IdentityRole role = new IdentityRole();
                    role.Name = "Admin";
                    IdentityResult resulte = roleMgr.CreateAsync(role).Result;
                    IdentityResult claim = roleMgr.AddClaimAsync(role, new Claim(type: "IsAdmin", value: "True")).Result;

                }
                ApplicationUser user = new ApplicationUser
                {
                    UserName = "admin@teste.com",
                    Email = "admin@teste.com",
                    Name = "Admin",
                    ExternalUserId = 1,
                    EmailConfirmed = true
                };

                IdentityResult userResult = userMgr.CreateAsync(user, "Admin123#").Result;
                IdentityResult roleResult = userMgr.AddToRoleAsync(user, "Admin").Result;
                IdentityResult claimResult = userMgr.AddClaimAsync(user, new Claim("GreenBadge", "True")).Result;

                if (!userResult.Succeeded || !roleResult.Succeeded || !claimResult.Succeeded)
                {
                    throw new InvalidOperationException("Failed to build user and roles");
                }
            }
        }
    }
}
