using Company.Data.Models;
using Company.Services.Interfaces;
using Company.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeeController(IEmployeeService employeeService , IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult Index(string searchInp)
        {
            if(string.IsNullOrEmpty(searchInp))
            {
                var emp = _employeeService.GetAll();
                ViewBag.message = "ViewBag";
                ViewData["TxtMessage"] = "ViewData";
                TempData["TxtMessage2"] = "TempData";
                return View(emp);
            }
            else
            {
                var emp = _employeeService.GetEmployeeByName(searchInp);
                return View(emp);
            }
            
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Departments = _departmentService.GetAll();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _employeeService.Add(employee);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("employeeError", "ValidationErrors");
                return View(employee);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("employeeError", ex.Message);
                return View(employee);
            }
        }
    }
}
