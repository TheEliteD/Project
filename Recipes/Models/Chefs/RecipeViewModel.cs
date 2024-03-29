using ChefsEntity = Recipes.Data.Entities.Chef;

namespace Recipes.Models.Chefs
{
    public class ChefsViewModel
    {
        public int Id { get; set; }

        public string ChefReviews { get; set; }

        public string TopChefs { get; set; }


        public ChefsViewModel()
        {
        }

        public ChefsViewModel(ChefsEntity chef)
        {
            Id = chef.Id;
            ChefReviews = chef.ChefReviews;
            TopChefs = chef.TopChefs;
        }
    }
}