using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Models.Employees
{
   public  enum EmployeeType
    {
        FullTime,
        PartTime,
       
    }
  public  enum Gender
    {
        Male,
        Female,
    }
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } =null!;
        [EmailAddress]
        public string? Email { get; set; } = null!;
        
        public string? Address { get; set; }
        [Range(24,50,ErrorMessage = "Age must be between 24 and 50")]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Gender Gender { get; set; }




        }
}
