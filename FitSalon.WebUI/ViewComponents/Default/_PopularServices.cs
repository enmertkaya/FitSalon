using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.Default
{
    public class _PopularServices : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager (new EFServiceDal());
       
        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetList();
            return View(values);
        }
    }
}
