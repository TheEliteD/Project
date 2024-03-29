using RecipeEntity = Recipes.Data.Entities.Recipe;

namespace Recipes.Models.Employee
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }

        public CreateRecipeViewModel()
        { }

        public CreateRecipeViewModel(RecipeEntity recipe)
        {
            Name = recipe.Name;
            Ingredients = recipe.Ingredients;
            Description = recipe.Description;
        }
    }
}