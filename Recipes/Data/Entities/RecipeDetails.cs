using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
    public class RecipeDetails
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual Recipe Recipe { get; set; }

        public RecipeDetails()
        {
        }

        public RecipeDetails(int id, string name, string ingredients, string description)
            : this(name, ingredients, description)
        {
            Id = id;
        }

        public RecipeDetails(string name, string ingredients, string description)
        {
            Name = name;
            Ingredients = ingredients;
            Description = description;
        }
    }
}
