using FitSalon.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.MemberDashboard
{
    public class _ServiceList : ViewComponent
    {
        private readonly IServiceService _serviceService;

        public _ServiceList(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IViewComponentResult Invoke()
        {
            var values = _serviceService.TGetList();
            return View(values);
        }
    }
}
