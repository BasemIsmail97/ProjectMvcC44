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
            builder.Property(e=>e.Address).HasColumnType("nvarchar(50)");
            builder.Property(e=>e.Salary).HasColumnType("decimal(10,2)");
            builder.Property(e=>e.Gender).HasColumnType("nvarchar(10)");
            builder.Property(e=>e.EmployeeType).HasColumnType("nvarchar(10)");
            builder.Property(d => d.Createdon).HasDefaultValueSql("getdate()");
            builder.Property(d => d.LastModificationOn).HasDefaultValueSql("getdate()");


        }
    }
}
