﻿using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{


    [Area("Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
