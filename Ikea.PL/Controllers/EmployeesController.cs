using IKEA.BLL.Serveces.Employee;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq.Expressions;

namespace IKEA.PL.Controllers
{
    public class EmployeesController(IEmployeeService employeeService, ILogger<EmployeesController> logger, IWebHostEnvironment environment) : Controller
    {
        private readonly IEmployeeService _employeeService = employeeService;
        private readonly ILogger<EmployeesController> _logger = logger;
        private readonly IWebHostEnvironment _environment = environment;

        #region Index
        public IActionResult Index()
        {
            var Employees = _employeeService.GetAllEmployees();
            return View(Employees);

        }
        #endregion
        #region Details

        public IActionResult Details(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();

        }
        [HttpPost]
        public IActionResult Create(BLL.DTOS.Employee.CreatedEmployeeDto createdEmployee)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _employeeService.AddEmployee(createdEmployee);
                    if (result > 0)
                    {

                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create Employee. Please try again.");

                    }



                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);

                    }
                    else
                    {
                        _logger.LogError(ex.Message, "An error occurred while creating a Employee.");
                        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");


                    }

                }
            }


            return View(createdEmployee);
        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            var EmployeeViewModel = new PL.Models.ViewModels.Employee.EmployeeViewModel
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                HiringDate = employee.HiringDate,
                Gender = employee.Gender,
                EmployeeType= employee.EmployeeType



            };
            return View(EmployeeViewModel);


        }
        [HttpPost]
        public IActionResult Edit(PL.Models.ViewModels.Employee.EmployeeViewModel employeeViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var updatedEmployeeDto = new BLL.DTOS.Employee.UpdatedEmployeeDto
                    {
                        Id = employeeViewModel.Id,
                        Name = employeeViewModel.Name,
                        Age = employeeViewModel.Age,
                        Address = employeeViewModel.Address,
                        Salary = employeeViewModel.Salary,
                        IsActive = employeeViewModel.IsActive,
                        Email = employeeViewModel.Email,
                        PhoneNumber = employeeViewModel.PhoneNumber,
                        HiringDate = employeeViewModel.HiringDate,
                        Gender= employeeViewModel.Gender,
                        EmployeeType= employeeViewModel.EmployeeType
                    };
                    int result = _employeeService.UpdateEmployee(updatedEmployeeDto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update Employee. Please try again.");
                    }

                }
                catch (Exception ex)
                {
                    if (_environment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                    }
                    else
                    {
                        _logger.LogError(ex.Message, "An error occurred while updating an Employee.");
                        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                    }
                }

            }
            return View(employeeViewModel);
        }
        #endregion
        #region Delete
        [HttpPost]

        public IActionResult Delete(int id)
        {
            try
            {
                bool isDeleted = _employeeService.DeleteEmployee(id);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception ex)
            {
                if (_environment.IsDevelopment())
                {
                    return BadRequest(ex.Message);
                }
                else
                {
                    _logger.LogError(ex.Message, "An error occurred while deleting an Employee.");
                    return BadRequest("An unexpected error occurred. Please try again later.");
                }
            }
        }
        #endregion
    }
}





