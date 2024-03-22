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

namespace Recipes.Tests.Controllers
{
    public class RecipesControllerTests2
    {
        private RecipesController recipesController;
        private ApplicationDbContext applicationContext;

        [SetUp] 
        public void SetUp()
        {
            applicationContext = SetUpApplicationConext();
            recipesController = new RecipesController(applicationContext);
        }

        [TearDown]
        public void TearDown()
        {
            recipesController.Dispose();
            applicationContext.Dispose();
            applicationContext.Database.EnsureDeleted();
        }

        [Test]
        public async Task AddTest()
        {
            var _recipe = new Recipe { Id = 1, Name = "Test Recipe 1", Ingredients = "Test Ingredients 1", Description = "Test Description 1" };
            await recipesController.Create(_recipe);
            var createdRecipe = applicationContext.Recipe.LastOrDefault();
            Assert.That(createdRecipe, Is.EqualTo(_recipe), "Recipe is different than expected");
        }

        private ApplicationDbContext SetUpApplicationConext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            return new ApplicationDbContext(options.Options);
        }
    }
}