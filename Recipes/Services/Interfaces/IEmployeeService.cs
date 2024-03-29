using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Services.Interfaces
{
    public interface IEmployeeService
    {
        void Add(CreateEmployeeViewModel employee);

        IEnumerable<EmployeeViewModel> GetAll();

        void Delete(int id);

        void Edit(EmployeeViewModel employee);

        EmployeeViewModel Get(int id);
    }
}