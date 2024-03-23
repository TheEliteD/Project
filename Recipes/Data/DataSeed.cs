using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Recipes.Data.Constants;

namespace Recipes.Data
{
    public static class DataSeed
    {
        public static void SeedUserRoles(WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            var roles = Enum.GetValues(typeof(Roles));

            foreach (var role in roles)
            {
                var roleName = role.ToString();

                var roleExists = dbContext.Roles.Any(roleEntity => roleEntity.Name == role);
                if (!roleExists)
                {
                    var identityRole = new IdentityRole(roleName)
                    {
                        NormalizedName = roleName.ToUpper(),
                    };

                  dbContext.Roles.Add(identityRole);
                }
            }
            
            dbContext.SaveChanges();
        }
    }
}
