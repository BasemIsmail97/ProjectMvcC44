using IKEA.DAL.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Repositories.Employee
{
    public class EmployeeRepository(ApplicationDbcontext dbcontext) : Generic.GenericRepository<IKEA.DAL.Models.Employees.Employee>(dbcontext), IEmployeeRepository
    {
      


    }
}
