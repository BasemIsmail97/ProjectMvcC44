using IKEA.BLL.DTOS.Department;
using IKEA.DAL.Models.Departments;
using IKEA.DAL.Repositories.Department;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.BLL.Serveces.Department
{
    public class DepartmentService(IDepartmentRepo departmentRepo) : IDepartmentService
    {
        public IEnumerable<DepartmentsDTO> GetAllDepartments()
        {
            var Departments = departmentRepo.GetAll();
            var DepartmentsToReturns = Departments.Select(d => new DepartmentsDTO

            {
                DeptId = d.Id,
                Name = d.Name,
                Code = d.Code,
                Description = d.Description,
                DateOfCreation = d.Createdon


            });
            return DepartmentsToReturns;
        }
        public DepartmentDetailsDTO? GetDepartmentById(int id)
        {
            var Department = departmentRepo.GetById(id);

            if (Department == null) return null;
            else
            {
                var DepartmentToReturn = new DepartmentDetailsDTO()
                {
                    Id = Department.Id,
                    Name = Department.Name,
                    Code = Department.Code,
                    Description = Department.Description,
                    Createdon = Department.Createdon,
                    CreatedBy = Department.CreatedBy,
                    LastModificationBy = Department.LastModificationBy,
                    LastModificationOn = Department.LastModificationOn,
                    IsDeleted = Department.IsDeleted,



                };
                return DepartmentToReturn;
            }




        }
        public int AddDepartment(CreatedDepartmentDto createdDepartment)
        {
            var department = new DAL.Models.Departments.Department()
            {
                Name = createdDepartment.Name,
                Code = createdDepartment.Code,
                Description = createdDepartment.Description,
                Createdon = createdDepartment.DateOfCreation,

            };
            return departmentRepo.Add(department);

        }
        public int UpdateDepartment(UpdatedDepartmentDto updatedDepartment)
        {
            var department = new DAL.Models.Departments.Department();
            department.Id = updatedDepartment.Id;
            department.Name = updatedDepartment.Name;
            department.Code = updatedDepartment.Code;
            department.Description = updatedDepartment.Description;
            department.Createdon = updatedDepartment.DateOfCreation;
            return departmentRepo.Update(department);
        }
        public bool DeleteDepartment(int id)
        {
            var department = departmentRepo.GetById(id);
            if (department == null) return false;
            else
            {
                int result = departmentRepo.Delete(department);
                if (result > 0) return true;
                else return false;
            }
        }
    }
} 
