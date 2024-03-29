using Microsoft.AspNetCore.Mvc;
using Recipes.Models.Employee;
using Recipes.Models.Chefs;
using Recipes.Services.Interfaces;

namespace Recipes.Controllers
{
    public class ChefsController : Controller
    {
        private readonly IChefsService chefService;

        public ChefsController(IChefsService chefService)
        {
            this.chefService = chefService;
        }

        public IActionResult Index()
        {
            var chefs = chefService.GetAll();

            return View(chefs);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateChefsViewModel chef)
        {
            chefService.Add(chef);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            chefService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = chefService.Get(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(ChefsViewModel chef)
        {
            chefService.Edit(chef);

            return RedirectToAction(nameof(Index));
        }
    }
}