using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Recipes.Models;

namespace Recipes.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Recipes.Models.Recipe> Recipe { get; set; } = default!;
        public DbSet<Recipes.Models.Chefs> Chefs { get; set; } = default!;

        internal async Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
