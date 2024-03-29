using Recipes.Data;
using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;
using Recipes.Repositories.Interfaces;

namespace Recipes.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private readonly ApplicationDbContext context;

        public RecipeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Recipe recipe)
        {
            if (recipe is null)
            {
                throw new ArgumentException("Recipe can't be null!");
            }

            context.Recipe.Add(recipe);

            context.SaveChanges();
        }

        public IEnumerable<Recipe> GetAll()
            => context.Recipe.ToList();

        public void Delete(int id)
        {
            var recipe = Get(id);
            // ToDo: add null value validation

            context.Recipe.Remove(recipe);
            context.SaveChanges();
        }

        public void Edit(RecipesViewModel recipe)
        {
            var entity = Get(recipe.Id);

            entity.Name = recipe.Name;
            entity.Ingredients = recipe.Ingredients;
            entity.Description = recipe.Description;

            context.SaveChanges();
        }

        public Recipe Get(int id)
            => context.Recipe.FirstOrDefault(product => product.Id == id);
    }
}