using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Recipes.Data.Entities;
using Recipes.Models.Employee;

namespace Recipes.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new ApplicationUserEntityConfiguration());
        }

        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeDetails> RecipeDetails { get; set; } = default!;
        public DbSet<Recipes.Models.Chefs> Chefs { get; set; } = default!;
        public DbSet<Employee> Employees { get; set; }
    }
}
