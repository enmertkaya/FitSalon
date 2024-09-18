using FitSalon.DtoLayer.DTOs.MemberDTOs;
using FitSalon.EntityLayer.Concrete;
using FitSalon.WebUI.Areas.Member.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Route("Member/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditDTO userEditViewModel = new UserEditDTO();
            userEditViewModel.Name = values.Name;
            userEditViewModel.Surname = values.Surname;
            userEditViewModel.PhoneNumber = values.PhoneNumber;
            userEditViewModel.Email = values.Email;
            return View(userEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserEditDTO p)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (p.ImageURL != null)
            {
                var resource = Directory.GetCurrentDirectory();
                var extension = Path.GetExtension(p.ImageFile.FileName);
                var imagename = Guid.NewGuid() + extension;
                var savelocation = resource + "/wwwroot/userimages/" + imagename;
                var stream = new FileStream(savelocation, FileMode.Create);
                await p.ImageFile.CopyToAsync(stream);
                user.ImageURL = imagename;
            }
            user.Name = p.Name;
            user.Surname = p.Surname;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, p.Password);
            user.PhoneNumber = p.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("SignIn", "Login");
            }
            return View();
        }

    }
}