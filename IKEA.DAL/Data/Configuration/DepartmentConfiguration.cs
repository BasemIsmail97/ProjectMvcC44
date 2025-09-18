

namespace IKEA.DAL.Data.Department
{
    public class DepartmentConfiguration : IEntityTypeConfiguration<Models.Departments.Department>
    {
      
        public void Configure(EntityTypeBuilder<Models.Departments.Department> builder)
        {
            builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d=>d.Name).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(d=>d.Code).HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(d => d.Createdon).HasDefaultValueSql("getdate()");
            builder.Property(d => d.LastModificationOn).HasComputedColumnSql("getdate()");


        }
    }
   
}
