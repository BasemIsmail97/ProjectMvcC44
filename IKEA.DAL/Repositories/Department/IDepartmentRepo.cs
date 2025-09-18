using IKEA.DAL.Models.Departments;

namespace IKEA.DAL.Repositories.Department
{
    public interface IDepartmentRepo
    {
        int Add(Models.Departments.Department department);
        int Delete(Models.Departments.Department department);
        IEnumerable<Models.Departments.Department> GetAll(bool WithTracking = false);
        Models.Departments.Department? GetById(int id, bool WithTracking = false);
        int Update(Models.Departments.Department department);
    }
}