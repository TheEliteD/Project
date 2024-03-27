using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Recipes;
using Recipes.Services.Interfaces;

namespace Recipes.Controllers
{
    public class RecipesController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipesController(IRecipeService productService)
        {
            this.recipeService = productService;
        }

        public IActionResult Index()
        {
            var recipes = recipeService.GetAll();

            return View(recipes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateRecipeViewModel recipe)
        {
            recipeService.Add(recipe);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            recipeService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = recipeService.Get(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(RecipeViewModel recipe)
        {
            recipeService.Edit(recipe);

            return RedirectToAction(nameof(Index));
        }
    }
}