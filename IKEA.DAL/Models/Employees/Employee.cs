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
        FullTime=1,
        PartTime=2,
       
    }
  public  enum Gender
    {
        Male=1,
        Female=2,
    }
    public class Employee : ModelBase
    {
       
        public string Name { get; set; } =null!;
        [EmailAddress]
        public string? Email { get; set; } = null!;
        
        public string? Address { get; set; }
        [Range(24,50,ErrorMessage = "Age must be between 24 and 50")]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        public decimal Salary { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? HiringDate { get; set; }
        public string EmployeeType { get; set; }

        public string Gender { get; set; }




        }
}
