using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using FitSalon.BusinessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNet.Identity;

namespace FitSalon.WebUI.Controllers
{
    public class ServiceController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> ServiceDetails(int id)
        {
            ViewBag.i = id;
            var values = serviceManager.TGetByID(id);
            return View(values);
        }
        [HttpPost]
        public IActionResult ServiceDetails(Service p)
        {
            return View();
        }
    }
}
