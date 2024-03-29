using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Services.Interfaces
{
    public interface IRecipeService
    {
        void Add(CreateRecipesViewModel recipe);

        IEnumerable<RecipesViewModel> GetAll();

        void Delete(int id);

        void Edit(RecipesViewModel recipe);

		RecipesViewModel Get(int id);
    }
}