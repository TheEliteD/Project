using Microsoft.EntityFrameworkCore;
using Recipes.Data;
using Recipes.Data.Entities;
using Recipes.Repositories;

namespace Recipies.Tests.Repositories
{
    internal class RecipeRepositoryTests
    {
        private RecipeRepository recipeRepository;
        private ApplicationDbContext context;

        [SetUp]
        public void SetUp()
        {
            context = SetUpApplicationContext();
            recipeRepository = new RecipeRepository(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void GivenARecipe_WhenAddingARecipe_AddsIt()
        {
            var recipe = new Recipe("new recipe", "ingredients", "description");

            recipeRepository.Add(recipe);

            var createdRecipe = context.Recipe.LastOrDefault();

            Assert.AreEqual(recipe, createdRecipe, "Recipe is different than expected");
        }

        [Test]
        public void GivenNullRecipe_WhenAddingARecipe_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => recipeRepository.Add(null));

            Assert.That(
                exception.Message, Is.EqualTo("Recipe can't be null!"),
                "Exception message is different than expexted");
        }

        [Test]
        public void WhenGettingAll_ReturnsAllRecipes()
        {
            var expectedProducts = SeedRecipes();

            var products = recipeRepository.GetAll();

            Assert.AreEqual(expectedProducts, products);
        }

        [Test]
        public void GivenAnExistingId_WhenGettingARecipe_ReturnsTheRecipe()
        {
            var expectedProducts = SeedRecipes();
            var expectedProduct = expectedProducts.First();

            var product = recipeRepository.Get(expectedProduct.Id);

            Assert.AreEqual(expectedProduct, product, "Product is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingARecipe_ReturnsTheRecipe()
        {
            SeedRecipes();
            var nonExistingId = -1;

            var recipe = recipeRepository.Get(nonExistingId);

            Assert.Null(recipe);
        }

        private IEnumerable<Recipe> SeedRecipes()
        {
            var products = new[]
            {
                new Recipe(1, "recipe1", "ingredients1", "description1"),
                new Recipe(2, "recipe2", "ingredients2", "description2"),
                new Recipe(3, "recipe3", "ingredients3", "description3")
            };

            context.Recipe.AddRange(products);
            context.SaveChanges();

            return products;
        }


        private ApplicationDbContext SetUpApplicationContext()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("UnitTestsDb");

            return new ApplicationDbContext(options.Options);
        }
    }
}