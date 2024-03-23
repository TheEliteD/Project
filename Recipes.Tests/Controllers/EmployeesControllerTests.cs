using Google;
using Moq;
using Microsoft.EntityFrameworkCore;
using Recipes.Controllers;
using Recipes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Recipes.Models;
using Recipes.Models.Employee;
using System.Runtime.ConstrainedExecution;
using Microsoft.AspNetCore.Mvc;

namespace Recipes.Tests.Controllers
{
    public class EmployeesControllerTests
    {
        private EmployeesController employeesController;
        private ApplicationDbContext applicationContext;

        [SetUp] 
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            employeesController = new EmployeesController(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            employeesController.Dispose();
            applicationContext.Dispose();
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddTestAsync()
        {
            var employee = new AddEmployeeViewModel
            {
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 50000,
                DateOfBirth = new DateTime(1990, 1, 1),
                Department = "Engineering"
            };

            var result = await employeesController.Add(employee);

            Assert.IsInstanceOf<RedirectToActionResult>(result);
            var redirectResult = (RedirectToActionResult)result;
            Assert.AreEqual("Index", redirectResult.ActionName);
        }

        private ApplicationDbContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationDbContext(options.Options);
        }
    }
}