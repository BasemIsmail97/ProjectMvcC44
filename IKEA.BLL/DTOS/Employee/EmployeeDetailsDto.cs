using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.DTOS.Employee
{
    public class EmployeeDetailsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        [EmailAddress]
        public string? Email { get; set; } = null!;

        public string? Address { get; set; }
        [Range(24, 50, ErrorMessage = "Age must be between 24 and 50")]
        public int Age { get; set; }
        public bool IsActive { get; set; }
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime HiringDate { get; set; }
        public string EmployeeType { get; set; }

        public string Gender { get; set; }
        public int CreatedBy { get; set; }

        public DateTime Createdon { get; set; }
        public int LastModificationBy { get; set; }
        public DateTime LastModificationOn { get; set; }
    }
}
