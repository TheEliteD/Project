using Recipes.Models.Employee;
using Recipes.Models.Chefs;

namespace Recipes.Services.Interfaces
{
    public interface IChefsService
    {
        void Add(CreateChefsViewModel chef);

        IEnumerable<ChefsViewModel> GetAll();

        void Delete(int id);

        void Edit(ChefsViewModel chef);

        ChefsViewModel Get(int id);
    }
}