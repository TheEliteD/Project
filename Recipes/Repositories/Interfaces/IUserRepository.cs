using Recipes.Areas.Identity.IndData;
using Recipes.Models.User;

namespace Recipes.Repositories.Interfaces
{
	public interface IUserRepository
	{
		IEnumerable<UserViewModel> GetAll();
	}
}
