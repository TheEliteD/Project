using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);

        IEnumerable<Recipe> GetAll();

        void Delete(int id);

        void Edit(RecipesViewModel recipe);

        Recipe Get(int id);
    }
}