using Microsoft.EntityFrameworkCore;
using Recipes.Controllers;
using Recipes.Data;
using Recipes.Models.Employee;
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

        [Test]
        public async Task View_Returns_View_With_Valid_Id()
        {
            // Arrange
            var validEmployeeId = Guid.NewGuid();
            var employee = new Employee
            {
                Id = validEmployeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 50000,
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Department = "IT"
            };
            await applicationContext.Employees.AddAsync(employee);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await employeesController.View(validEmployeeId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.EqualTo("View"));
            Assert.That(viewResult.Model, Is.InstanceOf<UpdateEmployeeViewModel>());
            var viewModel = viewResult.Model as UpdateEmployeeViewModel;
            Assert.That(viewModel.Id, Is.EqualTo(validEmployeeId)); // Ensure the Id matches the one passed to the method
            Assert.That(viewModel.Name, Is.EqualTo(employee.Name));
            Assert.That(viewModel.Email, Is.EqualTo(employee.Email));
            Assert.That(viewModel.Salary, Is.EqualTo(employee.Salary));
            Assert.That(viewModel.DateOfBirth, Is.EqualTo(employee.DateOfBirth));
            Assert.That(viewModel.Department, Is.EqualTo(employee.Department));
        }

        [Test]
        public async Task View_Redirects_To_Index_With_Invalid_Id()
        {
            // Arrange
            var invalidEmployeeId = Guid.NewGuid();

            // Act
            var result = await employeesController.View(invalidEmployeeId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        [Test]
        public async Task View_Updates_Employee_And_Redirects_To_Index_With_Valid_Model()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var model = new UpdateEmployeeViewModel
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 50000,
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Department = "IT"
            };
            await applicationContext.Employees.AddAsync(new Employee
            {
                Id = employeeId,
                Name = "Initial Name",
                Email = "initial.email@example.com",
                Salary = 40000,
                DateOfBirth = DateTime.Parse("1985-01-01"),
                Department = "HR"
            });
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await employeesController.View(model);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var updatedEmployee = await applicationContext.Employees.FindAsync(employeeId);
            Assert.That(updatedEmployee, Is.Not.Null);
            Assert.That(updatedEmployee.Name, Is.EqualTo(model.Name));
            Assert.That(updatedEmployee.Email, Is.EqualTo(model.Email));
            Assert.That(updatedEmployee.Salary, Is.EqualTo(model.Salary));
            Assert.That(updatedEmployee.DateOfBirth, Is.EqualTo(model.DateOfBirth));
            Assert.That(updatedEmployee.Department, Is.EqualTo(model.Department));
        }


        [Test]
        public async Task Delete_Removes_Employee_And_Redirects_To_Index_With_Valid_Model()
        {
            // Arrange
            var employeeId = Guid.NewGuid();
            var model = new UpdateEmployeeViewModel
            {
                Id = employeeId
            };
            await applicationContext.Employees.AddAsync(new Employee
            {
                Id = employeeId,
                Name = "John Doe",
                Email = "john.doe@example.com",
                Salary = 50000,
                DateOfBirth = DateTime.Parse("1990-01-01"),
                Department = "IT"
            });
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await employeesController.Delete(model);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var deletedEmployee = await applicationContext.Employees.FindAsync(employeeId);
            Assert.That(deletedEmployee, Is.Null);
        }

        [Test]
        public async Task Delete_Returns_RedirectToIndex_When_Employee_Not_Found()
        {
            // Arrange
            var nonExistentEmployeeId = Guid.NewGuid();
            var model = new UpdateEmployeeViewModel
            {
                Id = nonExistentEmployeeId
            };

            // Act
            var result = await employeesController.Delete(model);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
        }

        private ApplicationDbContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationDbContext(options.Options);
        }
    }
}