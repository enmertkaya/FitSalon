using FitSalon.BusinessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Controllers
{
    [AllowAnonymous]
    public class PacketsController : Controller
    {
        private readonly IServiceService _serviceService;

        public PacketsController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        List<Service> packet = new List<Service>();
        public IActionResult Index()
        {
            packet = _serviceService.TGetList();
            return View(packet);
        }
    }
}
