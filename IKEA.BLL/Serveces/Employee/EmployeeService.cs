using AutoMapper;
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
    public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository = employeeRepository;
        private readonly IMapper _mapper = mapper;

        public IEnumerable<EmployeeDto> GetAllEmployees()
        {
            var Employees = _employeeRepository.GetAll();
            var EmployeesDto = _mapper.Map<IEnumerable<IKEA.DAL.Models.Employees.Employee>,IEnumerable<EmployeeDto>>(Employees);

            return EmployeesDto;
        }
        public EmployeeDetailsDto GetEmployeeById(int id)
        {
            var Employee = _employeeRepository.GetById(id);
            if (Employee == null) return null;
            else
            {
                var EmployeeDto = _mapper.Map<IKEA.DAL.Models.Employees.Employee, EmployeeDetailsDto>(Employee);
                return EmployeeDto;


            }
        }

        public int AddEmployee(CreatedEmployeeDto employeeDetails)
        {
            var Employee = _mapper.Map<CreatedEmployeeDto, IKEA.DAL.Models.Employees.Employee>(employeeDetails);

            return _employeeRepository.Add(Employee);
        }

        public int UpdateEmployee(UpdatedEmployeeDto employeeDetails)
        {
            var Employee = _mapper.Map<UpdatedEmployeeDto, IKEA.DAL.Models.Employees.Employee>(employeeDetails);

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
