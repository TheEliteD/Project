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
        public void AddTest()
        {
            var recipe = new Recipe(1, "burger", "beef", "yummy");
            //recipesController.Add(recipe);
        }

        private ApplicationDbContext SetUpApplicationConext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>();
            return new ApplicationDbContext(options.Options);
        }

        public void TestCreate()
        {
            //var recipe = new Recipe(1, "burger", "beef", "yummy");
        }
        /*
        private Mock<ApplicationDbContext> SetUpApplicationContextMock()
        {
            var applicationContextMocl = new Mock<ApplicationDbContext>();

            applicationContextMocl.Setup(mock => mock.Recipe.Add(It.IsAny<Recipe>()));

            return applicationContextMocl;
        }
        */
    }
}