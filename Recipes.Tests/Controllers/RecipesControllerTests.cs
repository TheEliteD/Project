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
    public class RecipesControllerTests
    {
        private readonly RecipesController _recipesController;

        [SetUp]
        public void SetUp()
        {

        }

        public void TestCreate()
        {

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