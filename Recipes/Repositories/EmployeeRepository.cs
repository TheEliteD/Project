/*using Recipes.Data;
using Recipes.Data.Entities;
using Recipes.Migrations;
using Recipes.Models.Employee;
using Recipes.Models.Recipes;
using Recipes.Repositories.Interfaces;

namespace Recipes.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Employee employee)
        {
            if (employee is null)
            {
                throw new ArgumentException("Employee can't be null!");
            }

            context.Employees.Add(employee);

            context.SaveChanges();
        }

        public IEnumerable<Employee> GetAll()
            => context.Employees.ToList();

        public void Delete(int id)
        {
            var employee = Get(id);
            // ToDo: add null value validation

            context.Employees.Remove(employee);
            context.SaveChanges();
        }

        public void Edit(EmployeeViewModel employee)
        {
            var entity = Get(employee.Id);

            entity.Name = employee.Name;
            entity.Email = employee.Email;
            entity.Salary = employee.Salary;
            entity.DateOfBirth = employee.DateOfBirth;
            entity.Department = employee.Department;

            context.SaveChanges();
        }

        public Employee Get(int id)
            => context.Employees.FirstOrDefault(product => product.Id == id);
    }
}*/