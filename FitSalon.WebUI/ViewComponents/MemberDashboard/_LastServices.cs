using FitSalon.BusinessLayer.Abstract;
using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitSalon.WebUI.ViewComponents.MemberDashboard
{
    public class _LastServices : ViewComponent
    {
        ServiceManager serviceManager = new ServiceManager(new EFServiceDal());

        

        public IViewComponentResult Invoke()
        {
            var values = serviceManager.TGetLast4Services();
            return View(values);
        }
    }
}
