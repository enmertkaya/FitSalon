using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Member.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
