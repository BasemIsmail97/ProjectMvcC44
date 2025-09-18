using IKEA.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.Employee
{
    public class EmployeeRepository(ApplicationDbcontext dbcontext) : IEmployeeRepository
    {
        public IEnumerable<Models.Employees.Employee> GetAll(bool WithTracking = false)
        {
            if (WithTracking)
            {
                return dbcontext.Employees.ToList();
            }
            return dbcontext.Employees.AsNoTracking().ToList();
        }
        public Models.Employees.Employee? GetById(int id, bool WithTracking = false)
        {
            if (WithTracking)
            {
                return dbcontext.Employees.FirstOrDefault(x => x.Id == id);
            }
            return dbcontext.Employees.AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
        public int Add(Models.Employees.Employee employee)
        {
            dbcontext.Employees.Add(employee);
            return dbcontext.SaveChanges();
        }
        public int Update(Models.Employees.Employee employee)
        {
            dbcontext.Employees.Update(employee);
            return dbcontext.SaveChanges();
        }
        public int Delete(Models.Employees.Employee employee)
        {
            dbcontext.Employees.Remove(employee);
            return dbcontext.SaveChanges();
        }


    }
}
