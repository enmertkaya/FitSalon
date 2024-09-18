using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitSalon.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    public class ReservationController : Controller
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());
        ReservationManager reservationManager = new ReservationManager(new EFReservationDal());

        private readonly UserManager<AppUser> _userManager;
        public ReservationController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> MyCurrentReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByApproved(values.Id);
            return View(valueslist);
        }
        public async Task<IActionResult> MyOldReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valuesList = reservationManager.GetListWithReservationByPrevious(values.Id);
            return View(valuesList);
        }
        public async Task<IActionResult> MyRejectedReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByRejected(values.Id);
            return View(valueslist);
        }
        public async Task<IActionResult> MyApprovalReservation()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            var valueslist = reservationManager.GetListWithReservationByWaitApproval(values.Id);
            return View(valueslist);
        }

        [HttpGet]
        public IActionResult NewReservation()
        {
            List<SelectListItem> values = (from x in serviceManager.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.ServiceID.ToString()
                                           }).ToList();
            ViewBag.VNR = values;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> NewReservation(Reservation p)
        {
            var userId = await _userManager.GetUserAsync(User);
            p.AppUserID = userId.Id;
            p.Status = "Onay Bekliyor";
            reservationManager.TInsert(p);
            var url = "/Member/Reservation/MyApprovalReservation/";
            return Redirect(url);
        }
    }
}
