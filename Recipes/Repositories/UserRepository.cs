using Recipes.Areas.Identity.IndData;
using Recipes.Data;
using Recipes.Models.User;
using Recipes.Repositories.Interfaces;

namespace Recipes.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext dbContext;

		public UserRepository(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}
		public IEnumerable<UserViewModel> GetAll()
#pragma warning disable CS8619 // Nullability of reference types in value doesn't match target type.
			=> dbContext.Users
				.ToList()
				.Select(userEntity =>
			{
				var userRole = dbContext.UserRoles
				.FirstOrDefault(userRoleEntity => userRoleEntity.UserId == userEntity.Id);
				if (userRole == null)
				{
					return null;
				}

				var role = dbContext.Roles
					.FirstOrDefault(roleEntity => roleEntity.Id == userEntity.Id);

				return new UserViewModel(
					userEntity.Id,
					userEntity.Email,
					userEntity.UserName,
					role?.Name);
			})
			.Where(user => user != null);
#pragma warning restore CS8619 // Nullability of reference types in value doesn't match target type.
	}
}