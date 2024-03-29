using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Services.Interfaces
{
    public interface IRecipeService
    {
        void Add(CreateRecipeViewModel recipe);

        IEnumerable<RecipeViewModel> GetAll();

        void Delete(int id);

        void Edit(RecipeViewModel recipe);

        RecipeViewModel Get(int id);
    }
}