using Microsoft.AspNetCore.Mvc;
using Recipes.Services.Interfaces;

namespace Recipes.Controllers
{
	public class UserController : Controller
	{
		private readonly IUserService userService;

		public UserController(IUserService userService)
		{
			this.userService = userService;
		}

		//User/Index <=> /User
		public IActionResult Index()
		{
			var user = userService.GetAll();
			return View(user);
		}

		//public async Task<IActionResult> IndexAsync()
		//{
		//	var user = await userService.GetAllAsync();

		//	return View(user);
		//}
	}
}
