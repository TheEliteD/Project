using Recipes.Data.Entities;
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

        public void Add(CreateRecipeViewModel recipe)
        {
            var recipeDetails = new RecipeDetails(recipe.Name, recipe.Ingredients, recipe.Description);
            var recipeEntity = new Recipe(recipe.Name, recipe.Ingredients, recipe.Description);

            recipeRepository.Add(recipeEntity);
        }

        public IEnumerable<RecipeViewModel> GetAll()
        {
            var recipeEntities = recipeRepository.GetAll();

            var recipes = recipeEntities.Select(recipe => new RecipeViewModel(recipe));

            return recipes;
        }

        public RecipeViewModel Get(int id)
        {
            var recipe = recipeRepository.Get(id);

            return new RecipeViewModel(recipe);
        }

        public void Edit(RecipeViewModel product)
            => recipeRepository.Edit(product);

        public void Delete(int id)
            => recipeRepository.Delete(id);
    }
}