using System.ComponentModel.DataAnnotations;

namespace Recipes.Data.Entities
{
    public class Employee
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public int Salary { get; set; }

        [Required]
        public DateTime Birthday { get; set; }

        [Required]
        public string Department { get; set; }

        public Employee()
        {
        }

        public Employee(Guid id, string name, string email, int salary, DateTime birthday, string department)
            : this(name, email, salary, birthday, department)
        {
            Id = id;
        }

        public Employee(string name, string email, int salary, DateTime birthday, string department)
        {
            Name = name;
            Email = email;
            Salary = salary;
            Birthday = birthday;
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
            Birthday == other.Birthday &&
            Department == other.Department;
    }
}