using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace FitSalon.WebUI.ViewComponents.AdminDashboard
{
    public class _AdminEmployeeList : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
