using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace IKEA.DAL.Data.Contexts
{
    public class ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options) : DbContext(options)
    {
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }
        #region DbSet
        public DbSet<Models.Departments.Department> Departments { get; set; } 
        public DbSet<Models.Employees.Employee> Employees { get; set; }
        #endregion
    }
}
