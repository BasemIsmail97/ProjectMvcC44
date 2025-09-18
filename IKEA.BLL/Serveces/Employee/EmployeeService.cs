using IKEA.BLL.DTOS.Employee;
using IKEA.DAL.Models.Employees;
using IKEA.DAL.Repositories.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Serveces.Employee
{
    public class EmployeeService(IEmployeeRepository employeeRepository) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var Employees = _employeeRepository.GetAll();
            var EmployeesToReturn = Employees.Select(e => new EmployeeDto()
            {
                Id = e.Id,
                Name = e.Name,
                Salary = e.Salary,
                Age = e.Age,
                EmployeeType = e.EmployeeType,

            });
            return EmployeesToReturn;
        }
        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var Employee = _employeeRepository.GetById(id);
            if (Employee == null) return null;
            else
            {
                var EmployeeToReturn = new EmployeeDetailsDto()
                {
                    Id = Employee.Id,
                    Name = Employee.Name,
                    Salary = Employee.Salary,
                    Age = Employee.Age,
                    EmployeeType = Employee.EmployeeType,
                    Address = Employee.Address,
                    Gender = Employee.Gender,
                    Email = Employee.Email,
                    HiringDate = Employee.HiringDate,
                    IsActive = Employee.IsActive,
                    PhoneNumber = Employee.PhoneNumber,

                };
                return EmployeeToReturn;

            }
        }

        public int AddEmployee(EmployeeDetailsDto employeeDetails)
        {
            var Employee = new IKEA.DAL.Models.Employees.Employee()
            {
                Name = employeeDetails.Name,
                Salary = employeeDetails.Salary,
                Address = employeeDetails.Address,
                Gender = employeeDetails.Gender,
                Email = employeeDetails.Email,
                IsActive = employeeDetails.IsActive,
                PhoneNumber = employeeDetails.PhoneNumber,
                Age = employeeDetails.Age,
                EmployeeType = employeeDetails.EmployeeType,
                HiringDate = employeeDetails.HiringDate,

            };
            return _employeeRepository.Add(Employee);
        }

        public int UpdateEmployee(EmployeeDetailsDto employeeDetails)
        {
            var Employee = new IKEA.DAL.Models.Employees.Employee()
            {
                Id = employeeDetails.Id,
                Name = employeeDetails.Name,
                Salary = employeeDetails.Salary,
                Address = employeeDetails.Address,
                Gender = employeeDetails.Gender,
                Email = employeeDetails.Email,
                IsActive = employeeDetails.IsActive,
                PhoneNumber = employeeDetails.PhoneNumber,
                Age = employeeDetails.Age,
                EmployeeType = employeeDetails.EmployeeType,
                HiringDate = employeeDetails.HiringDate,

            };
            return _employeeRepository.Update(Employee);
        }

        public bool DeleteEmployee(int id)
        {
            var Employee = _employeeRepository.GetById(id);
            if (Employee == null) return false;
            else
            {
                int result = _employeeRepository.Delete(Employee);
                if (result > 0) return true;
                else return false;
            }
        }
    }
}
