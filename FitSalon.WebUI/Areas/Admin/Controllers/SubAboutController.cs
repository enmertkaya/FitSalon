﻿using FitSalon.DataAccessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class SubAboutController : Controller
    {
        private readonly ISubAboutDal _subAboutDal;

        public SubAboutController(ISubAboutDal subAboutDal)
        {
            _subAboutDal = subAboutDal;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var values = _subAboutDal.GetByID(1);
            return View(values);
        }

        [HttpPost]
        public IActionResult Index(SubAbout p)
        {
            _subAboutDal.Update(p);
            return RedirectToAction("Index");
        }
    }
}
