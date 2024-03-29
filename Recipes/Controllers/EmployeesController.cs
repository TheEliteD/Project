using Microsoft.AspNetCore.Mvc;
using Recipes.Data.Entities;
using Recipes.Migrations;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;
using Recipes.Services.Interfaces;

namespace Recipes.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            this.employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var employees = employeeService.GetAll();

            return View(employees);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateEmployeeViewModel employee)
        {
            employeeService.Add(employee);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            employeeService.Delete(id);

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var product = employeeService.Get(id);

            return View(product);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeViewModel employee)
        {
            employeeService.Edit(employee);

            return RedirectToAction(nameof(Index));
        }
    }
}