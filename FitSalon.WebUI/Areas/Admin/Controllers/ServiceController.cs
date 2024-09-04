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
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        EmployeeManager employeeManager = new EmployeeManager(new EFEmployeeDal());

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }

        [HttpGet]
        public IActionResult AddService()
        {
            List<SelectListItem> values = (from x in employeeManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.EmployeeName,
                                               Value = x.EmployeeID.ToString()
                                           }).ToList();
            ViewBag.SLG = values;
            return View();
        }

        [HttpPost]
        public IActionResult AddService(Service service)
        {
            serviceManager.TInsert(service);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteService(int id)
        {
            var values = serviceManager.TGetByID(id);
            serviceManager.TDelete(values);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            List<SelectListItem> values1 = (from x in employeeManager.TGetList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName,
                                                Value = x.EmployeeID.ToString()
                                            }).ToList();
            ViewBag.SLG = values1;
            var values = serviceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            serviceManager.TUpdate(service);
            return RedirectToAction("Index");
        }
    }
}
