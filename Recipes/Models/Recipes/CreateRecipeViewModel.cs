using RecipeEntity = Recipes.Data.Entities.Recipe;

namespace Recipes.Models.Recipes
{
    public class CreateRecipeViewModel
    {
        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }

        public CreateRecipeViewModel()
        { }

        public CreateRecipeViewModel(RecipeEntity product)
        {
            Name = product.Name;
            Ingredients = product.Ingredients;
            Description = product.Description;
        }
    }
}