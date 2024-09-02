using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.Areas.Member.Controllers
{
    [AllowAnonymous]
    [Area("Member")]
    public class ServiceController : Controller
    {
        

        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());

        public IActionResult Index()
        {
            var values = serviceManager.TGetList();
            return View(values);

        }
    }
}
