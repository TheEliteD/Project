using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
    public class Chef
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ChefReviews { get; set; }

        [Required]
        public string TopChefs { get; set; }

        public Chef()
        {
        }

        public Chef(int id, string chefReview, string topChefs)
            : this(chefReview, topChefs)
        {
            Id = id;
        }

        public Chef(string chefReview, string topChefs)
        {
            ChefReviews = chefReview;
            TopChefs = topChefs;
        }

        public override bool Equals(object? other)
            => Equals((Chef)other);

        public bool Equals(Chef other)
            => other != null &&
            Id == other.Id &&
            ChefReviews == other.ChefReviews &&
            TopChefs == other.TopChefs;
    }
}