using RecipeEntity = Recipes.Data.Entities.Recipe;

namespace Recipes.Models.Recipes
{
    public class RecipesViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Ingredients { get; set; }

        public string Description { get; set; }


        public RecipesViewModel()
        {
        }

        public RecipesViewModel(RecipeEntity product)
        {
            Id = product.Id;
            Name = product.Name;
            Ingredients = product.Ingredients;
            Description = product.Description;
        }
    }
}