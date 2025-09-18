using IKEA.BLL.Serveces.Department;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    public class DepartmentsController(IDepartmentService departmentService,ILogger<DepartmentsController> logger,IWebHostEnvironment enviroment) : Controller
    {
        private readonly IDepartmentService _departmentService = departmentService;
        private readonly ILogger<DepartmentsController> _logger = logger;
        private readonly IWebHostEnvironment _enviroment = enviroment;
       

        #region Index
        public IActionResult Index()
        {
            var Departments = _departmentService.GetAllDepartments();
            return View(Departments);
        }
        #endregion
        #region Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(BLL.DTOS.Department.CreatedDepartmentDto createdDepartmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentService.AddDepartment(createdDepartmentDto);
                    if (result > 0)
                    {
                        TempData["success"] = "Department Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to create department. Please try again.");
                       
                    }

                    

                }
                catch (Exception ex)
                {
                    if (_enviroment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        
                    }
                    else
                    {
                        _logger.LogError(ex.Message, "An error occurred while creating a department.");
                        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                        

                    }
                   
                }
            }
           
                return View(createdDepartmentDto);
            
        }
        #endregion
        #region Details
        [HttpGet]
        public IActionResult Details(int id)
        {
            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }
        #endregion
        #region Update
        [HttpGet]
        public IActionResult Edit(int id)
        {

            {
                var department = _departmentService.GetDepartmentById(id);
                if (department == null)
                {
                    return NotFound();
                }
                var DepartmentViewModel = new Models.ViewModels.Department.DepartmentViewModels
                {
                    Name = department.Name,
                    Code = department.Code,
                    Description = department.Description,
                    DateOfCreation = department.Createdon,
                };
                return View(DepartmentViewModel);
            }
        }
        [HttpPost]
        public IActionResult Edit( Models.ViewModels.Department.DepartmentViewModels departmentViewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    
                    var updatedDepartmentDto = new BLL.DTOS.Department.UpdatedDepartmentDto
                    {
                        Id = departmentViewModel.Id,
                        Name = departmentViewModel.Name,
                        Code = departmentViewModel.Code,
                        Description = departmentViewModel.Description,
                        DateOfCreation = departmentViewModel.DateOfCreation,
                    };
                    int  Result = _departmentService.UpdateDepartment( updatedDepartmentDto);
                    if (Result>0)
                    {
                        TempData["success"] = "Department Updated Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Failed to update department. Please try again.");
                        
                    }
                }
                catch (Exception ex)
                {
                    if (_enviroment.IsDevelopment())
                    {
                        ModelState.AddModelError(string.Empty, ex.Message);
                        
                    }
                    else
                    {
                        _logger.LogError(ex.Message, "An error occurred while updating a department.");
                        ModelState.AddModelError(string.Empty, "An unexpected error occurred. Please try again later.");
                        
                    }
                   
                }
            }
            return View(departmentViewModel);
        }

        #endregion
        #region delete

        [HttpPost]
        public IActionResult Delete(int id)
        {

            try
            {
                bool isDeleted = _departmentService.DeleteDepartment(id);
                if (isDeleted)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                   ModelState.AddModelError(string.Empty, "Failed to delete department. Please try again.");
                     
                }
            }
            catch (Exception ex)
            {
                if (_enviroment.IsDevelopment())
                {
                    TempData["error"] = ex.Message;
                }
                else
                {
                    _logger.LogError(ex.Message, "An error occurred while deleting a department.");
                    TempData["error"] = "An unexpected error occurred. Please try again later.";
                }
            }
            return RedirectToAction("Index");
        }
        #endregion
    }
}
