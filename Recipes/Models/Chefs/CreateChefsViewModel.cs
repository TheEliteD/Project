using ChefsEntity = Recipes.Data.Entities.Chef;

namespace Recipes.Models.Chefs
{
	public class CreateChefsViewModel
	{

		public string ChefReviews { get; set; }

		public string TopChefs { get; set; }

		public CreateChefsViewModel()
		{ }

		public CreateChefsViewModel(ChefsEntity chef)
		{
            ChefReviews = chef.ChefReviews;
            TopChefs = chef.TopChefs;
		}
	}
}