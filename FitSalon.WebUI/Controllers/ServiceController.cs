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
    [AllowAnonymous]
    public class ServiceController : Controller
    {

        private readonly IServiceService _serviceService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;

        public ServiceController(IServiceService serviceService, Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _serviceService = serviceService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.v12 = "12";
            var values = _serviceService.TGetList();
            return View(values);
        }

        [HttpGet]
        public async Task<IActionResult> ServiceDetails(int id)
        {
            ViewBag.i = id;
            ViewBag.servID = id;
            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.userID = user.Id;
            }


            var values = _serviceService.TGetServiceWithEmployee(id);

            return View(values);
        }
        [HttpPost]
        public IActionResult ServiceDetails(Service p)
        {
            return View();
        }
    }
}
