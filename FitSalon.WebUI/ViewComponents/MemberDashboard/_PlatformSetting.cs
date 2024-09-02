using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitSalon.WebUI.ViewComponents.MemberDashboard
{
    public class _PlatformSetting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
