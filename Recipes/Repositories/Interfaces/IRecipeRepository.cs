using Recipes.Data.Entities;
using Recipes.Models.Recipes;

namespace Recipes.Repositories.Interfaces
{
    public interface IRecipeRepository
    {
        void Add(Recipe recipe);

        IEnumerable<Recipe> GetAll();

        void Delete(int id);

        void Edit(RecipeViewModel recipe);

        Recipe Get(int id);
    }
}