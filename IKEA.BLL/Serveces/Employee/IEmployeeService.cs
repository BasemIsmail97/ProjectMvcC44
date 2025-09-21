using IKEA.BLL.DTOS.Employee;

namespace IKEA.BLL.Serveces.Employee
{
    public interface IEmployeeService
    {
        int AddEmployee(CreatedEmployeeDto employeeDetails);
        bool DeleteEmployee(int id);
        IEnumerable<EmployeeDto> GetAllEmployees();
        EmployeeDetailsDto GetEmployeeById(int id);
        int UpdateEmployee(UpdatedEmployeeDto employeeDetails);
    }
}