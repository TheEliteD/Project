using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
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

        public Recipe(int id, string name, string ingredients, string description)
            : this(name, ingredients, description)
        {
            Id = id;
        }

        public Recipe(string name, string ingredients, string description)
        {
            Name = name;
            Ingredients = ingredients;
            Description = description;
        }

        public override bool Equals(object? other)
            => Equals((Recipe)other);

        public bool Equals(Recipe other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Ingredients == other.Ingredients &&
            Description == other.Description;
    }
}