using Microsoft.AspNetCore.Identity;
using Recipes.Areas.Identity.IndData;
using Recipes.Data;
using Recipes.Data.Constants;
using Recipes.Models.User;
using Recipes.Repositories.Interfaces;
using Recipes.Services.Interfaces;

namespace Recipes.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository userRepository;
		private readonly UserManager<AppUser> userManager;

		public UserService(IUserRepository userRepository, 
			UserManager<AppUser> userManager)
		{
			this.userRepository = userRepository;
			this.userManager = userManager;
		}
		public IEnumerable<UserViewModel> GetAll()
			=> userRepository.GetAll();

		public async Task<IEnumerable<UserViewModel>> IndexAsync()
		{
			var users = new List<UserViewModel>();

			var userRoles = Enum.GetValues(typeof(UserRoles));
			foreach(var role in userRoles)
			{
				var usersinRoleEntities = await userManager.GetUsersInRoleAsync(role.ToString());
				var uesrsInRole = usersinRoleEntities
					.Select(user => new UserViewModel(user.Id, user.Email, user.UserName, role.ToString()));

				users.AddRange(uesrsInRole);
			}

			return users;
		}
	}
}
