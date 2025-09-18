using IKEA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA.DAL.Data.Configuration
{
    public class EmployeeConiguration : IEntityTypeConfiguration<Models.Employees.Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
           builder.HasKey(e => e.Id);
            builder.Property(e => e.Name).IsRequired().HasMaxLength(50);

        }
    }
}
