using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Recipes.Controllers;
using Recipes.Data;
using Recipes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recipies.Tests.Controllers
{
    internal class ChefsControllerTests
    {
        private ChefsController chefsController;
        private ApplicationDbContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            chefsController = new ChefsController(applicationContext);
        }

        [Test]
        public async Task Create_Adds_Chefs_And_Redirects_To_Index_With_Valid_Model()
        {
            // Arrange
            var chefs = new Chefs
            {
                Id = 1,
                ChefReviews = "Good reviews",
                TopChefs = "Top chefs"
            };

            // Act
            var result = await chefsController.Create(chefs);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var addedChefs = await applicationContext.Chefs.FindAsync(chefs.Id);
            Assert.That(addedChefs, Is.Not.Null);
            Assert.That(addedChefs.ChefReviews, Is.EqualTo(chefs.ChefReviews));
            Assert.That(addedChefs.TopChefs, Is.EqualTo(chefs.TopChefs));
        }

        [Test]
        public async Task Create_Returns_View_With_Invalid_Model()
        {
            // Arrange
            var invalidChefs = new Chefs
            {
                Id = 1, // Ensure the Id is unique and valid
                // Missing required fields to make ModelState invalid
            };
            chefsController.ModelState.AddModelError("ChefReviews", "ChefReviews is required");

            // Act
            var result = await chefsController.Create(invalidChefs);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty);
            Assert.That(viewResult.Model, Is.EqualTo(invalidChefs));
        }

        [Test]
        public async Task Edit_Returns_View_With_Valid_Id()
        {
            // Arrange
            var validChefsId = 1;
            var expectedChefs = new Chefs
            {
                Id = validChefsId,
                ChefReviews = "Good reviews",
                TopChefs = "Top chefs"
            };
            applicationContext.Chefs.Add(expectedChefs);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await chefsController.Edit(validChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty);
            Assert.That(viewResult.Model, Is.EqualTo(expectedChefs));
        }

        [Test]
        public async Task Edit_Returns_NotFound_With_Null_Id()
        {
            // Arrange
            int? invalidChefsId = null;

            // Act
            var result = await chefsController.Edit(invalidChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_Returns_NotFound_With_Nonexistent_Id()
        {
            // Arrange
            var nonexistentChefsId = 999;

            // Act
            var result = await chefsController.Edit(nonexistentChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_Returns_View_With_Valid_Id()
        {
            // Arrange
            var validChefsId = 1; // Assume this ID exists in the database
            var expectedChefs = new Chefs
            {
                Id = validChefsId,
                ChefReviews = "Good reviews",
                TopChefs = "Top chefs"
            };
            applicationContext.Chefs.Add(expectedChefs);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await chefsController.Delete(validChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty); // Ensure it returns the default view
            Assert.That(viewResult.Model, Is.EqualTo(expectedChefs));
        }

        [Test]
        public async Task Delete_Returns_NotFound_With_Null_Id()
        {
            // Arrange
            int? invalidChefsId = null;

            // Act
            var result = await chefsController.Delete(invalidChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_Returns_NotFound_With_Nonexistent_Id()
        {
            // Arrange
            var nonexistentChefsId = 999; // Assume this ID does not exist in the database

            // Act
            var result = await chefsController.Delete(nonexistentChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task DeleteConfirmed_Removes_Chefs_And_Redirects_To_Index()
        {
            // Arrange
            var chefsId = 1; // Assume this ID exists in the database
            var chefs = new Chefs
            {
                Id = chefsId,
                ChefReviews = "Good reviews",
                TopChefs = "Top chefs"
            };
            applicationContext.Chefs.Add(chefs);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await chefsController.DeleteConfirmed(chefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var deletedChefs = await applicationContext.Chefs.FindAsync(chefsId);
            Assert.That(deletedChefs, Is.Null);
        }

        [Test]
        public async Task DeleteConfirmed_Does_Not_Remove_Nonexistent_Chefs()
        {
            // Arrange
            var nonexistentChefsId = 999; // Assume this ID does not exist in the database

            // Act
            var result = await chefsController.DeleteConfirmed(nonexistentChefsId);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));
            // Ensure no chefs were deleted
            var deletedChefs = await applicationContext.Chefs.FindAsync(nonexistentChefsId);
            Assert.That(deletedChefs, Is.Null);
        }

        private ApplicationDbContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationDbContext(options.Options);
        }
    }
}