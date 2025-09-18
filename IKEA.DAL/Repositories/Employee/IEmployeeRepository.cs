





namespace IKEA.DAL.Repositories.Employee
{
    public interface IEmployeeRepository
    {
        int Add(Models.Employees.Employee employee);
        int Delete(Models.Employees.Employee employee);
        IEnumerable<Models.Employees.Employee> GetAll(bool WithTracking = false);
        Models.Employees.Employee? GetById(int id, bool WithTracking = false);
        int Update(Models.Employees.Employee employee);
    }
}