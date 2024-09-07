using FitSalon.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitSalon.WebUI.ViewComponents.AdminDashboard
{
    public class _Cards1Statistic : ViewComponent
    {
        Context c = new Context();
        public IViewComponentResult Invoke()
        {
            ViewBag.v1 = c.Services.Count();
            ViewBag.v2 = c.Users.Count();
            return View();
        }
    }
}
