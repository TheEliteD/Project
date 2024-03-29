using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;
using Recipes.Repositories.Interfaces;
using Recipes.Services.Interfaces;

namespace Recipes.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly IRecipeRepository recipeRepository;

        public RecipeService(IRecipeRepository recipeRepository)
        {
            this.recipeRepository = recipeRepository;
        }

        public void Add(CreateRecipesViewModel recipe)
        {
            var recipeDetails = new RecipeDetails(recipe.Name, recipe.Ingredients, recipe.Description);
            var recipeEntity = new Recipe(recipe.Name, recipe.Ingredients, recipe.Description);

            recipeRepository.Add(recipeEntity);
        }

        public IEnumerable<RecipesViewModel> GetAll()
        {
            var recipeEntities = recipeRepository.GetAll();

            var recipes = recipeEntities.Select(recipe => new RecipesViewModel(recipe));

            return recipes;
        }

        public RecipesViewModel Get(int id)
        {
            var recipe = recipeRepository.Get(id);

            return new RecipesViewModel(recipe);
        }

        public void Edit(RecipesViewModel product)
            => recipeRepository.Edit(product);

        public void Delete(int id)
            => recipeRepository.Delete(id);
    }
}