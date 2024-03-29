using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Chefs;
using Recipes.Repositories.Interfaces;
using Recipes.Services.Interfaces;

namespace Chefs.Services
{
    public class ChefsService : IChefsService
    {
        private readonly IChefsRepository chefRepository;

        public ChefsService(IChefsRepository chefRepository)
        {
            this.chefRepository = chefRepository;
        }

        public void Add(CreateChefsViewModel chef)
        {
            var chefDetails = new ChefDetails(chef.ChefReviews, chef.TopChefs);
            var chefEntity = new Chef( chef.ChefReviews, chef.TopChefs);

            chefRepository.Add(chefEntity);
        }

        public IEnumerable<ChefsViewModel> GetAll()
        {
            var chefEntities = chefRepository.GetAll();

            var chef = chefEntities.Select(chef => new ChefsViewModel(chef));

            return chef;
        }

        public ChefsViewModel Get(int id)
        {
            var chef = chefRepository.Get(id);

            return new ChefsViewModel(chef);
        }

        public void Edit(ChefsViewModel product)
            => chefRepository.Edit(product);

        public void Delete(int id)
            => chefRepository.Delete(id);
    }
}