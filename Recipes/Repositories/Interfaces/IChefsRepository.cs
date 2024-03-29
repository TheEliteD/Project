using Recipes.Data.Entities;
using Recipes.Models.Chefs;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Repositories.Interfaces
{
    public interface IChefsRepository
    {
        void Add(Chef recipe);

        IEnumerable<Chef> GetAll();

        void Delete(int id);

        void Edit(ChefsViewModel recipe);

        Chef Get(int id);
    }
}