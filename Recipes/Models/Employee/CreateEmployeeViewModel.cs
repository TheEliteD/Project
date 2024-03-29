﻿using EmployeeEntity = Recipes.Data.Entities.Employee;

namespace Recipes.Models.Employee
{
    public class CreateEmployeeViewModel
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Salary { get; set; }
        public DateTime Birthday { get; set; }
        public string Department { get; set; }

        public CreateEmployeeViewModel()
        { }

        public CreateEmployeeViewModel(EmployeeEntity employee)
        {
            Name = employee.Name;
            Email = employee.Email;
            Salary = employee.Salary;
            Birthday = employee.Birthday;
            Department = employee.Department;
        }
    }
}