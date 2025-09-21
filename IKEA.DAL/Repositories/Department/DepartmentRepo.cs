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
    public class DepartmentRepo(ApplicationDbcontext dbcontext) : Generic.GenericRepository<IKEA.DAL.Models.Departments.Department>(dbcontext), IDepartmentRepo
    {
        private readonly ApplicationDbcontext _dbcontext ;
       
    }
}
