using Recipes.Models.User;

namespace Recipes.Services.Interfaces
{
	public interface IUserService
	{
		IEnumerable<UserViewModel> GetAll();

		Task<IEnumerable<UserViewModel>> IndexAsync();
	}
}
