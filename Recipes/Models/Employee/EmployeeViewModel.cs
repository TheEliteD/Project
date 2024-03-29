using Recipes.Data.Entities;
using Recipes.Migrations;
using EmployeeEntity = Recipes.Data.Entities.Employee;

namespace Recipes.Models.Employee
{
    public class EmployeeViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }


        public EmployeeViewModel()
        {
        }

        public EmployeeViewModel(EmployeeEntity employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            Email = employee.Email;
            Salary = employee.Salary;
            Birthday = employee.Birthday;
            Department = employee.Department;
        }
    }
}