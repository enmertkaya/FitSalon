﻿using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FitSalon.DtoLayer.DTOs.AppUserDTOs;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FitSalon.WebUI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FitSalon.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {

        private readonly Microsoft.AspNetCore.Identity.UserManager<AppUser> _userManager;

        public LoginController(Microsoft.AspNetCore.Identity.UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserRegisterViewModel p)
        {
            AppUser appUser = new AppUser()
            {
                ImageURL = p.ImageURL ?? "https://example.com/default-image.jpg",  // Geçici bir URL değeri atayın
                Name =p.Name,
                Surname = p.Surname,
                Email = p.EMail,
                UserName = p.Username,
                Gender = p.Gender ?? "NotSpecified"  // Gender null ise varsayılan olarak "NotSpecified" değeri atanır
            };
            if (p.Password == p.ConfirmPassword)
            {
                var result = await _userManager.CreateAsync(appUser, p.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("SignIn");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }

                }
            }
            return View(p);
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
    }
}
