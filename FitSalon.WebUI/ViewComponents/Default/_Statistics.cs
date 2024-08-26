using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.Default
{
    public class _Statistics : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using var c = new Context();
            ViewBag.v1 = c.Services.Count();
            ViewBag.v2 = c.Employees.Count();
            ViewBag.v3 = "325";
            return View();
        }
    }
}
