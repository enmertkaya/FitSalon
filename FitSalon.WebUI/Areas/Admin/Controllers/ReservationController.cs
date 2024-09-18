using FitSalon.BusinessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    [Area("Admin")]
    public class ReservationController : Controller
    {
        private readonly IReservationService _restinationService;
        private readonly IServiceService _serviceService;

        public ReservationController(IReservationService restinationService, IServiceService serviceService)
        {
            _restinationService = restinationService;
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            var values = _restinationService.GetAllReservation();
            return View(values);
        }

        public IActionResult ReservationApprove(int id) 
        {
            _restinationService.ApproveReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult ReservationReject(int id)
        {
            _restinationService.RejectReservation(id);
            return RedirectToAction("Index");
        }
        public IActionResult ReservationWaiting(int id)
        {
            _restinationService.WaitingApproveReservation(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditReservation(int id)
        {
            var values = _restinationService.TGetByID(id);
            List<SelectListItem> rdl = (from x in _serviceService.TGetList()
                                           select new SelectListItem
                                           {
                                               Text = x.City,
                                               Value = x.ServiceID.ToString()
                                           }).ToList();
            ViewBag.RDL = rdl;
            return View(values);

        }
        [HttpPost]
        public IActionResult EditReservation(Reservation p)
        {
            p.Status = "Onay Bekliyor";
            _restinationService.TUpdate(p);
            return RedirectToAction("Index");
        }
        public IActionResult DeleteReservation(int id)
        {
            var values = _restinationService.TGetByID(id);
            _restinationService.TDelete(values);
            return RedirectToAction("Index");
        }
    }
}
