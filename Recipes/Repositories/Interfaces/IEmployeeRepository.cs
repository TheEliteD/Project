using Recipes.Data.Entities;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;

namespace Recipes.Repositories.Interfaces
{
    public interface IEmployeeRepository
    {
        void Add(Employee employee);

        IEnumerable<Employee> GetAll();

        void Delete(int id);

        void Edit(EmployeeViewModel employee);

        Employee Get(int id);
    }
}