using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
    public class ChefDetails
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public string ChefReviews { get; set; }

        [Required]
        public string TopChefs { get; set; }

        public virtual Recipe Recipe { get; set; }

        public ChefDetails()
        {
        }

        public ChefDetails(int id, string review, string description)
            : this(review, description)
        {
            Id = id;
        }

        public ChefDetails(string chefReview, string topChefs)
        {
            ChefReviews = chefReview;
            TopChefs = topChefs;
        }
    }
}
