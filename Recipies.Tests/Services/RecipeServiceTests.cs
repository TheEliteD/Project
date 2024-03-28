using Moq;
using Recipes.Data.Entities;
using Recipes.Models.Recipes;
using Recipes.Repositories.Interfaces;
using Recipes.Services;

namespace Recipies.Tests.Services
{
    internal class RecipeServiceTests
    {
        private RecipeService service;
        private Mock<IRecipeRepository> recipeRepositoryMock;
        private readonly IEnumerable<Recipe> recipesInDatabase;

        public RecipeServiceTests()
        {
            recipesInDatabase = new[]
            {
                new Recipe(1, "Recipe1", "Ingredient1", "Description1"),
                new Recipe(2, "Recipe2", "Ingredient2", "Description2"),
                new Recipe(3, "Recipe3", "Ingredient3", "Description3")
            };
        }

        [SetUp]
        public void SetUp()
        {
            recipeRepositoryMock = SetUpRecipeRepositoryMock();
            service = new RecipeService(recipeRepositoryMock.Object);
        }

        [Test]
        public void GivenValidRecipe_WhenAddingARecipe_TheRecipeIsAdded()
        {

            var recipe = new CreateRecipeViewModel()
            {
                Name = "product",
                Ingredients = "ingredient",
                Description = "description",
            };
            service.Add(recipe);

            recipeRepositoryMock.Verify(
                mock => mock.Add(It.Is<Recipe>(recipeEntity =>
                    recipeEntity.Name == recipe.Name &&
                    recipeEntity.Ingredients == recipe.Ingredients &&
                    recipeEntity.Description == recipe.Description)),
                Times.Once);
        }

        [Test]
        public void GivenRecipesExist_WhenGettingAllRecipes_AllRecipesAreReturned()
        {
            var recipes = service.GetAll();

            Assert.That(
                recipes.Count(), Is.EqualTo(recipesInDatabase.Count()),
                "Products count different than expected");

            foreach (var recipesInDatabase in recipesInDatabase)
            {
                var productExists = recipes.Any(recipe =>
                        recipe.Id == recipesInDatabase.Id &&
                        recipe.Name == recipesInDatabase.Name &&
                        recipe.Ingredients == recipesInDatabase.Ingredients &&
                        recipe.Description == recipesInDatabase.Description);

                Assert.True(
                    productExists,
                    $"Product with Id {recipesInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoRecipesExist_WhenGettingAllRecipes_ReturnsEmptyCollection()
        {
            recipeRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Recipe>());

            var recipes = service.GetAll();

            Assert.That(recipes.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GivenAnExistingId_WhenGettingARecipe_ReturnsTheRecipe()
        {
            var expectedRecipe = recipesInDatabase.First();

            var recipe = service.Get(expectedRecipe.Id);

            Assert.That(recipe.Id, Is.EqualTo(expectedRecipe.Id));
            Assert.That(recipe.Name, Is.EqualTo(expectedRecipe.Name));
            Assert.That(recipe.Ingredients, Is.EqualTo(expectedRecipe.Ingredients));
            Assert.That(recipe.Description, Is.EqualTo(expectedRecipe.Description));
        }

        private Mock<IRecipeRepository> SetUpRecipeRepositoryMock()
        {
            var recipeRepositoryMock = new Mock<IRecipeRepository>();

            recipeRepositoryMock.Setup(mock => mock.Add(It.IsAny<Recipe>()));

            recipeRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(recipesInDatabase);

            recipeRepositoryMock
                .Setup(mock => mock.Get(recipesInDatabase.First().Id))
                .Returns(recipesInDatabase.First());

            return recipeRepositoryMock;
        }
    }
}