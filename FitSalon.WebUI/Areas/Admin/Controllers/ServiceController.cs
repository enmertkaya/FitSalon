using DocumentFormat.OpenXml.Wordprocessing;
using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IServiceService _serviceService;
        private readonly IEmployeeService _employeeService;

        public ServiceController(IServiceService serviceService, IEmployeeService employeeService)
        {
            _serviceService = serviceService;
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _serviceService.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            List<SelectListItem> values = (from x in _employeeService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.SLG = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service p)
        {
            _serviceService.TInsert(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            List<SelectListItem> values1 = (from x in _employeeService.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName,
                                                Value = x.EmployeeID.ToString()
                                            }).ToList();
            ViewBag.SLG = values1;
            var values = _serviceService.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _serviceService.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
