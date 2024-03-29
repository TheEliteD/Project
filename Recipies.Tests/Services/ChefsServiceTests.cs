using Chefs.Services;
using Moq;
using Recipes.Repositories.Interfaces;
using Recipes.Data.Entities;
using Recipes.Models.Chefs;

namespace Recipies.Tests.Services
{
    internal class ChefsServiceTests
    {
        private ChefsService service;
        private Mock<IChefsRepository> chefRepositoryMock;
        private readonly IEnumerable<Chef> chefsInDatabase;

        public ChefsServiceTests()
        {
            chefsInDatabase = new[]
            {
                new Chef(1, "review1", "chef1"),
                new Chef(2, "review2", "chef2"),
                new Chef(3, "review3", "chef3")
            };
        }

        [SetUp]
        public void SetUp()
        {
            chefRepositoryMock = SetUpChefRepositoryMock();
            service = new ChefsService(chefRepositoryMock.Object);
        }

        [Test]
        public void GivenValidChef_WhenAddingAChef_TheChefIsAdded()
        {

            var chef = new CreateChefsViewModel()
            {
                ChefReviews = "review",
                TopChefs = "chef"
            };
            service.Add(chef);

            chefRepositoryMock.Verify(
                mock => mock.Add(It.Is<Chef>(chefEntity =>
                    chefEntity.ChefReviews == chef.ChefReviews &&
                    chefEntity.TopChefs == chef.TopChefs)),
                Times.Once);
        }

        [Test]
        public void GivenChefsExist_WhenGettingAllChefs_AllChefsAreReturned()
        {
            var chefs = service.GetAll();

            Assert.That(
                chefs.Count(), Is.EqualTo(chefsInDatabase.Count()),
                "Products count different than expected");

            foreach (var chefsInDatabase in chefsInDatabase)
            {
                var productExists = chefs.Any(chef =>
                        chef.Id == chefsInDatabase.Id &&
                        chef.ChefReviews == chefsInDatabase.ChefReviews &&
                        chef.TopChefs == chefsInDatabase.TopChefs);

                Assert.True(
                    productExists,
                    $"Product with Id {chefsInDatabase.Id} doesn't exist");
            }
        }

        [Test]
        public void GivenNoChefsExist_WhenGettingAllChefs_ReturnsEmptyCollection()
        {
            chefRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(new List<Chef>());

            var chefs = service.GetAll();

            Assert.That(chefs.Count(), Is.EqualTo(0));
        }

        [Test]
        public void GivenAnExistingId_WhenGettingAChef_ReturnsTheChef()
        {
            var expectedChef = chefsInDatabase.First();

            var chef = service.Get(expectedChef.Id);

            Assert.That(chef.Id, Is.EqualTo(expectedChef.Id));
            Assert.That(chef.ChefReviews, Is.EqualTo(expectedChef.ChefReviews));
            Assert.That(chef.TopChefs, Is.EqualTo(expectedChef.TopChefs));
        }

        private Mock<IChefsRepository> SetUpChefRepositoryMock()
        {
            var chefRepositoryMock = new Mock<IChefsRepository>();

            chefRepositoryMock.Setup(mock => mock.Add(It.IsAny<Chef>()));

            chefRepositoryMock
                .Setup(mock => mock.GetAll())
                .Returns(chefsInDatabase);

            chefRepositoryMock
                .Setup(mock => mock.Get(chefsInDatabase.First().Id))
                .Returns(chefsInDatabase.First());

            return chefRepositoryMock;
        }
    }
}