using Company.Data.Models;
using Company.Repository.Interfaces;
using Company.Services.Dto;
using Company.Services.Interfaces;
using Company.Services.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.Web.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
            var dept = _departmentService.GetAll();
            return View(dept);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(DepartmentDto department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _departmentService.Add(department);
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("DepartmentError", "ValidationErrors");
                return View(department);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("DepartmentError",ex.Message);
                return View(department);
            }
        }
        [HttpGet]
        public IActionResult Details(int? id, string viewname= "Details")
        {
            var dept = _departmentService.GetById(id);
            if(dept is null)
            {
                return NotFound();
            }

            return View(viewname,dept);
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            return Details(id, "Update");
        }
        [HttpPost]
        //public IActionResult Update(int? id,Department department)
        //{
        //    if(department.ID != id.Value)
        //        return RedirectToAction("NotFound",null,"Home");
            
        //    _departmentService.Update(department);
        //    return RedirectToAction(nameof(Index));
        //}

        public ActionResult Delete(int id)
        {
            var dept = _departmentService.GetById(id);
            if (dept is null) 
                return RedirectToAction("NotFoundPage", null, "Home");
            
            dept.IsDeleted = true;
            /*_departmentService.Delete(dept);*/ //Hard
            //_departmentService.Update(dept); //Soft

            return RedirectToAction(nameof(Index));
        }
    }
}
