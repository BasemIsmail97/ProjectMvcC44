using IKEA.DAL.Data.Contexts;
using IKEA.DAL.Models.Departments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.Department
{
    public class DepartmentRepo(ApplicationDbcontext dbcontext) : Repositories.Department.IDepartmentRepo
    {
        public IEnumerable<Models.Departments.Department> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return dbcontext.Departments.ToList();
            }
            return dbcontext.Departments.AsNoTracking().ToList();
        }
        public Models.Departments.Department? GetById(int id, bool WithTracking = false)
        {
            if (WithTracking)
            {
                return dbcontext.Departments.FirstOrDefault(x => x.Id == id);
            }
            return dbcontext.Departments.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public int Add(Models.Departments.Department department)
        {
            dbcontext.Departments.Add(department);
            return dbcontext.SaveChanges();
        }
        public int Update(Models.Departments.Department department)
        {
            dbcontext.Departments.Update(department);
            return dbcontext.SaveChanges();
        }
        public int Delete(Models.Departments.Department department)
        {
            dbcontext.Departments.Remove(department);
            return dbcontext.SaveChanges();

        }
    }
}
