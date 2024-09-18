﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [AllowAnonymous]
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
