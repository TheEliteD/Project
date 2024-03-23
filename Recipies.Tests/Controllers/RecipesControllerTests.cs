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
    internal class RecipesControllerTests
    {
        private RecipesController employeesController;
        private ApplicationDbContext applicationContext;

        [SetUp]
        public void SetUp()
        {
            applicationContext = SetUpApplicationContext();
            employeesController = new RecipesController(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task Create_Adds_Recipe_And_Redirects_To_Index_With_Valid_Model()
        {
            // Arrange
            var recipe = new Recipe
            {
                Id = 1,
                Name = "Test Recipe",
                Ingredients = "Ingredient1, Ingredient2",
                Description = "Test Description"
            };

            // Act
            var result = await employeesController.Create(recipe);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var addedRecipe = await applicationContext.Recipe.FirstOrDefaultAsync(r => r.Id == recipe.Id);
            Assert.That(addedRecipe, Is.Not.Null);
            Assert.That(addedRecipe.Name, Is.EqualTo(recipe.Name));
            Assert.That(addedRecipe.Ingredients, Is.EqualTo(recipe.Ingredients));
            Assert.That(addedRecipe.Description, Is.EqualTo(recipe.Description));
        }

        [Test]
        public async Task Create_Returns_View_With_Invalid_Model()
        {
            // Arrange
            var invalidRecipe = new Recipe
            {
                Id = 1, // Ensure the Id is unique and valid
                // Missing required fields to make ModelState invalid
            };
            employeesController.ModelState.AddModelError("Name", "Name is required"); // Simulate ModelState error

            // Act
            var result = await employeesController.Create(invalidRecipe);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty); // Ensure it returns the default view
            Assert.That(viewResult.Model, Is.EqualTo(invalidRecipe));
        }

        [Test]
        public async Task Edit_Returns_View_With_Valid_Id()
        {
            // Arrange
            var validRecipeId = 1; // Assume this ID exists in the database
            var expectedRecipe = new Recipe
            {
                Id = validRecipeId,
                Name = "Test Recipe",
                Ingredients = "Ingredient1, Ingredient2",
                Description = "Test Description"
            };
            applicationContext.Recipe.Add(expectedRecipe);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await employeesController.Edit(validRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty); // Ensure it returns the default view
            Assert.That(viewResult.Model, Is.EqualTo(expectedRecipe));
        }

        [Test]
        public async Task Edit_Returns_NotFound_With_Null_Id()
        {
            // Arrange
            int? invalidRecipeId = null;

            // Act
            var result = await employeesController.Edit(invalidRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_Returns_NotFound_With_Nonexistent_Id()
        {
            // Arrange
            var nonexistentRecipeId = 999; // Assume this ID does not exist in the database

            // Act
            var result = await employeesController.Edit(nonexistentRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_Updates_Recipe_And_Redirects_To_Index_With_Valid_Model()
        {
            // Arrange
            var recipeId = 1;
            var originalRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Original Recipe Name",
                Ingredients = "Original Ingredients",
                Description = "Original Description"
            };
            applicationContext.Recipe.Add(originalRecipe);
            await applicationContext.SaveChangesAsync();

            var updatedRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Updated Recipe Name",
                Ingredients = "Updated Ingredients",
                Description = "Updated Description"
            };

            // Act
            var result = await employeesController.Edit(recipeId, updatedRecipe);

            // Assert
            Assert.That(result, Is.InstanceOf<RedirectToActionResult>());
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.That(redirectToActionResult.ActionName, Is.EqualTo("Index"));

            var editedRecipe = await applicationContext.Recipe.FindAsync(recipeId);
            Assert.That(editedRecipe, Is.Not.Null);
            Assert.That(editedRecipe.Name, Is.EqualTo(updatedRecipe.Name));
            Assert.That(editedRecipe.Ingredients, Is.EqualTo(updatedRecipe.Ingredients));
            Assert.That(editedRecipe.Description, Is.EqualTo(updatedRecipe.Description));
        }

        [Test]
        public async Task Edit_Returns_NotFound_When_Id_Does_Not_Match_Model_Id()
        {
            // Arrange
            var recipeId = 1;
            var originalRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Original Recipe Name",
                Ingredients = "Original Ingredients",
                Description = "Original Description"
            };
            applicationContext.Recipe.Add(originalRecipe);
            await applicationContext.SaveChangesAsync();

            var updatedRecipe = new Recipe
            {
                Id = recipeId + 1, // Different Id than the one passed to the method
                Name = "Updated Recipe Name",
                Ingredients = "Updated Ingredients",
                Description = "Updated Description"
            };

            // Act
            var result = await employeesController.Edit(recipeId, updatedRecipe);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Edit_Returns_View_With_Invalid_Model()
        {
            // Arrange
            var recipeId = 1;
            var originalRecipe = new Recipe
            {
                Id = recipeId,
                Name = "Original Recipe Name",
                Ingredients = "Original Ingredients",
                Description = "Original Description"
            };
            applicationContext.Recipe.Add(originalRecipe);
            await applicationContext.SaveChangesAsync();

            var invalidRecipe = new Recipe
            {
                Id = recipeId,
                // Missing required fields to make ModelState invalid
            };
            employeesController.ModelState.AddModelError("Name", "Name is required"); // Simulate ModelState error

            // Act
            var result = await employeesController.Edit(recipeId, invalidRecipe);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty); // Ensure it returns the default view
            Assert.That(viewResult.Model, Is.EqualTo(invalidRecipe));
        }

        [Test]
        public async Task Delete_Returns_View_With_Valid_Id()
        {
            // Arrange
            var validRecipeId = 1; // Assume this ID exists in the database
            var expectedRecipe = new Recipe
            {
                Id = validRecipeId,
                Name = "Test Recipe",
                Ingredients = "Ingredient1, Ingredient2",
                Description = "Test Description"
            };
            applicationContext.Recipe.Add(expectedRecipe);
            await applicationContext.SaveChangesAsync();

            // Act
            var result = await employeesController.Delete(validRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<ViewResult>());
            var viewResult = result as ViewResult;
            Assert.That(viewResult.ViewName, Is.Null.Or.Empty); // Ensure it returns the default view
            Assert.That(viewResult.Model, Is.EqualTo(expectedRecipe));
        }

        [Test]
        public async Task Delete_Returns_NotFound_With_Null_Id()
        {
            // Arrange
            int? invalidRecipeId = null;

            // Act
            var result = await employeesController.Delete(invalidRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        [Test]
        public async Task Delete_Returns_NotFound_With_Nonexistent_Id()
        {
            // Arrange
            var nonexistentRecipeId = 999; // Assume this ID does not exist in the database

            // Act
            var result = await employeesController.Delete(nonexistentRecipeId);

            // Assert
            Assert.That(result, Is.InstanceOf<NotFoundResult>());
        }

        private ApplicationDbContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationDbContext(options.Options);
        }
    }
}
