using Microsoft.AspNetCore.Identity;

namespace Recipes.Data
{
    public static class DataSeed
    {
        public static void SeedUserRoles(WebApplication webApplication)
        {
            using var scope = webApplication.Services.CreateScope();
            var dbContext = scope.ServiceProvider.GetService<ApplicationDbContext>();

            dbContext.Roles.Add(new IdentityRole("test test"));
        }
    }
}
