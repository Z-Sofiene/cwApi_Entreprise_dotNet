
namespace Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        public Gender Gender { get; set; }

        public int DepartmentId { get; set; }

        public string PhotoPath { get; set; }
        public Department? Department { get; set; }
    }

    public enum Gender
    {
        Male,
        Female
    }
}
