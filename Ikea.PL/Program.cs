using IKEA.BLL.Serveces.Department;
using IKEA.BLL.Serveces.Employee;
using IKEA.DAL.Data.Contexts;
using IKEA.DAL.Repositories.Department;
using IKEA.DAL.Repositories.Employee;
using Microsoft.EntityFrameworkCore;

namespace Ikea.PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

         builder.Services.AddControllersWithViews();
            #region Configure Services
            builder.Services.AddDbContext<ApplicationDbcontext>(OptionsBuilder =>
            {
               
                OptionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));



            });
            #region Department Service
            builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
            builder.Services.AddScoped<IDepartmentService, DepartmentService>();

            #endregion
            #region Employee Service
            builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            builder.Services.AddScoped<IEmployeeService, EmployeeService>();
            builder.Services.AddAutoMapper(e=>e.AddProfile(new IKEA.BLL.Profiles.EmployeeMappingProfile()));
            #endregion

            #endregion

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
