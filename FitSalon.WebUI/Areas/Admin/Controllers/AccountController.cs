using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Abstract.AbstractUOW;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using FitSalon.WebUI.Areas.Admin.Models;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]

    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public IActionResult Index()
        {
            var values = _accountService.TGetAccountWithEmployee();
            return View(values);
        }


        [HttpGet]
        public IActionResult SendUOW()
        {
            List<SelectListItem> values = (from x in _accountService.TGetAccountWithEmployee()
                                           select new SelectListItem
                                           {
                                               Text = x.Employee.EmployeeName,
                                               Value = x.AccountID.ToString()
                                           }).ToList();
            ViewBag.VGDX = values;
            return View();
        }

        [HttpPost]
        public IActionResult SendUOW(AccountViewModel model)
        {
            var valueSender = _accountService.TGetByID(model.SenderID);
            var valueReceiver = _accountService.TGetByID(model.ReceiverID);

            valueSender.Balance -= model.Amount;
            valueReceiver.Balance += model.Amount;

            List<Account> modifiedAccount = new List<Account>()
            {
                valueSender,
                valueReceiver,
            };

            _accountService.TMultiUpdate(modifiedAccount);
            return RedirectToAction("Index");
        }
    }
}
