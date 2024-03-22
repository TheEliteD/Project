/*using Moq;
using NUnit.Framework;
using Recipes.Controllers;
using Recipes.Data;
using Recipes.Models;
using System;
using System.Threading.Tasks;

namespace Recipes.Tests.Controllers
{
    [TestFixture]
    public class RecipesControllerTests
    {
        private MockRepository mockRepository;

        private Mock<ApplicationDbContext> mockApplicationDbContext;

        [SetUp]
        public void SetUp()
        {
            this.mockRepository = new MockRepository(MockBehavior.Strict);

            this.mockApplicationDbContext = this.mockRepository.Create<ApplicationDbContext>();
        }

        private RecipesController CreateRecipesController()
        {
            return new RecipesController(
                this.mockApplicationDbContext.Object);
        }

        [Test]
        public async Task Index_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();

            // Act
            var result = await recipesController.Index();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task ShowSearchForm_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();

            // Act
            var result = await recipesController.ShowSearchForm();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task ShowSearchResults_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            String SearchPhrase = null;

            // Act
            var result = await recipesController.ShowSearchResults(
                SearchPhrase);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Details_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            int? id = null;

            // Act
            var result = await recipesController.Details(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public void Create_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();

            // Act
            var result = recipesController.Create();

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Create_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            Recipe recipe = null;

            // Act
            var result = await recipesController.Create(
                recipe);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Edit_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            int? id = null;

            // Act
            var result = await recipesController.Edit(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Edit_StateUnderTest_ExpectedBehavior1()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            int id = 0;
            Recipe recipe = null;

            // Act
            var result = await recipesController.Edit(
                id,
                recipe);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task Delete_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            int? id = null;

            // Act
            var result = await recipesController.Delete(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }

        [Test]
        public async Task DeleteConfirmed_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var recipesController = this.CreateRecipesController();
            int id = 0;

            // Act
            var result = await recipesController.DeleteConfirmed(
                id);

            // Assert
            Assert.Fail();
            this.mockRepository.VerifyAll();
        }
    }
}
*/