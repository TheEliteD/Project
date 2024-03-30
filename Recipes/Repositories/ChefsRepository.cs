using Recipes.Data;
using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Chefs;
using Recipes.Repositories.Interfaces;

namespace Recipes.Repositories
{
    public class ChefsRepository : IChefsRepository
    {
        private readonly ApplicationDbContext context;

        public ChefsRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Chef chef)
        {
            if (chef is null)
            {
                throw new ArgumentException("Chefs can't be null!");
            }

            context.Chefs.Add(chef);

            context.SaveChanges();
        }

        public IEnumerable<Chef> GetAll()
            => context.Chefs.ToList();

        public void Delete(int id)
        {
            var chef = Get(id);
            // ToDo: add null value validation

            context.Chefs.Remove(chef);
            context.SaveChanges();
        }

        public void Edit(ChefsViewModel chefs)
        {
            var entity = Get(chefs.Id);
            entity.ChefReviews = chefs.ChefReviews;
            entity.TopChefs = chefs.TopChefs;

            context.SaveChanges();
        }

        public Chef Get(int id)
            => context.Chefs.FirstOrDefault(product => product.Id == id);
    }
}