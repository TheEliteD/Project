using System.ComponentModel.DataAnnotations;

namespace Recipes.Models
{
    // Model for the recipes
    public class Recipe
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Ingredients { get; set; }

        [Required]
        public string Description { get; set; }

        public Recipe()
        {
            
        }
    }
}