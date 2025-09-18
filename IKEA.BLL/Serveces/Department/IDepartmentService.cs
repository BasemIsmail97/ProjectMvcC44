using IKEA.BLL.DTOS.Department;

namespace IKEA.BLL.Serveces.Department
{
    public interface IDepartmentService
    {
        int AddDepartment(CreatedDepartmentDto createdDepartment);
        bool DeleteDepartment(int id);
        IEnumerable<DepartmentsDTO> GetAllDepartments();
        DepartmentDetailsDTO? GetDepartmentById(int id);
        int UpdateDepartment(UpdatedDepartmentDto updatedDepartment);
    }
}