using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using FitSalonDataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace FitSalon.WebUI.ViewComponents.Default
{
    public class _Feature1 : ViewComponent
    {
        Feature1Manager feature1Manager = new Feature1Manager(new EFFeature1Dal());


        public IViewComponentResult Invoke()
        {
            var values = feature1Manager.TGetList().Take(5).ToList();
            return View(values);

        }
    
        
    }
}
