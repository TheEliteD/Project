using Microsoft.AspNetCore.Identity;
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
                    dbContext.Roles.Add(new IdentityRole(roleName));
                }
            }

            dbContext.SaveChanges();
        }
    }
}
