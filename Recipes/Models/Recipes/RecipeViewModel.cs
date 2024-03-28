using RecipeEntity = Recipes.Data.Entities.Recipe;

namespace Recipes.Models.Recipes
{
    public class RecipeViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }


        public RecipeViewModel()
        {
        }

        public RecipeViewModel(RecipeEntity recipe)
        {
            Id = recipe.Id;
            Name = recipe.Name;
            Ingredients = recipe.Ingredients;
            Description = recipe.Description;
        }
    }
}