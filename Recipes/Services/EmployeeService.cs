/*using Recipes.Data.Entities;
using Recipes.Migrations;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;
using Recipes.Repositories.Interfaces;
using Recipes.Services.Interfaces;

namespace Recipes.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public void Add(CreateEmployeeViewModel employee)
        {
            var employeeEntity = new Employee(employee.Name, employee.Email, employee.Salary, employee.DateOfBirth, employee.Department);

            employeeRepository.Add(employeeEntity);
        }

        public IEnumerable<EmployeeViewModel> GetAll()
        {
            var employeeEntities = employeeRepository.GetAll();

            var employees = employeeEntities.Select(recipe => new EmployeeViewModel(recipe));

            return employees;
        }

        public EmployeeViewModel Get(int id)
        {
            var recipe = employeeRepository.Get(id);

            return new EmployeeViewModel(recipe);
        }

        public void Edit(EmployeeViewModel product)
            => employeeRepository.Edit(product);

        public void Delete(int id)
            => employeeRepository.Delete(id);
    }
}*/