using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public string Department { get; set; }

        public Employee()
        {
        }

        public Employee(int id, string name, string email, int salary, DateTime dateOfBirth, string department)
            : this(name, email, salary, dateOfBirth, department)
        {
            Id = id;
        }

        public Employee(string name, string email, int salary, DateTime dateOfBirth, string department)
        {
            Name = name;
            Email = email;
            Salary = salary;
            dateOfBirth = DateOfBirth;
            Department = department;
        }

        public override bool Equals(object? other)
            => Equals((Employee)other);

        public bool Equals(Employee other)
            => other != null &&
            Id == other.Id &&
            Name == other.Name &&
            Email == other.Email &&
            Salary == other.Salary &&
            DateOfBirth == other.DateOfBirth &&
            Department == other.Department;
    }
}