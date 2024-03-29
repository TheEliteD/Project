using Microsoft.EntityFrameworkCore;
using Recipes.Data;
using Recipes.Data.Entities;
using Recipes.Repositories;

namespace Recipies.Tests.Repositories
{
    internal class ChefsRepositoryTests
    {
        private ChefsRepository chefsRepository;
        private ApplicationDbContext context;

        [SetUp]
        public void SetUp()
        {
            context = SetUpApplicationContext();
            chefsRepository = new ChefsRepository(context);
        }

        [TearDown]
        public void TearDown()
        {
            context.Database.EnsureDeleted();
        }

        [Test]
        public void GivenAChef_WhenAddingAChef_AddsIt()
        {
            var chef = new Chef("new review", "new chef");

            chefsRepository.Add(chef);

            var createdChef = context.Chefs.LastOrDefault();

            Assert.AreEqual(chef, createdChef, "Chef is different than expected");
        }

        [Test]
        public void GivenNullChef_WhenAddingAChef_Throws()
        {
            var exception = Assert.Throws<ArgumentException>(() => chefsRepository.Add(null));

            Assert.That(
                exception.Message, Is.EqualTo("Chef can't be null!"),
                "Exception message is different than expexted");
        }

        [Test]
        public void WhenGettingAll_ReturnsAllChefs()
        {
            var expectedProducts = SeedChefs();

            var products = chefsRepository.GetAll();

            Assert.AreEqual(expectedProducts, products);
        }

        [Test]
        public void GivenAnExistingId_WhenGettingAChef_ReturnsTheChef()
        {
            var expectedProducts = SeedChefs();
            var expectedProduct = expectedProducts.First();

            var product = chefsRepository.Get(expectedProduct.Id);

            Assert.AreEqual(expectedProduct, product, "Product is different than expected");
        }

        [Test]
        public void GivenNonExistingId_WhenGettingAChef_ReturnsTheChef()
        {
            SeedChefs();
            var nonExistingId = -1;

            var chef = chefsRepository.Get(nonExistingId);

            Assert.Null(chef);
        }

        private IEnumerable<Chef> SeedChefs()
        {
            var products = new[]
            {
                new Chef(1, "yummy", "Angelov"),
                new Chef(2, "very ok", "Manchev"),
                new Chef(3, "yes", "Toshkov")
            };

            context.Chefs.AddRange(products);
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