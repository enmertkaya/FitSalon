using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
