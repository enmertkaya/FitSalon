using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.BusinessLayer.ValidationRules;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            AdminEmployeeValidator validationRules = new AdminEmployeeValidator();
            ValidationResult validationResult = validationRules.Validate(employee);
            if(validationResult.IsValid)
            {
                _employeeService.TInsert(employee);
                return Redirect("/Admin/Employee/Index");
            }
            else
            {
                foreach(var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }
        [HttpGet]
        public IActionResult EditEmployee(int id)
        {
            var values = _employeeService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult EditEmployee(Employee employee)
        {
            _employeeService.TUpdate(employee);
            return Redirect("/Admin/Employee/Index");

        }
        public IActionResult ChangeToTrue(int id)
        {
            _employeeService.TChangeToTrueByEmployee(id);
            return Redirect("/Admin/Employee/Index");
        }
        public IActionResult ChangeToFalse(int id)
        {
            _employeeService.TChangeToFalseByEmployee(id);
            return Redirect("/Admin/Employee/Index");
        }
        public IActionResult DeleteEmployee(int id)
        {
            var values = _employeeService.TGetByID(id);
            _employeeService.TDelete(values);
            return Redirect("/Admin/Employee/Index");
        }

    }
}
