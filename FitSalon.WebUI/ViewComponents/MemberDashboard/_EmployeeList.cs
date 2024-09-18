using FitSalon.BusinessLayer.Concrete;
using FitSalon.DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitSalon.WebUI.ViewComponents.MemberDashboard
{
    public class _EmployeeList : ViewComponent
    {
        EmployeeManager employeeManager = new EmployeeManager(new EFEmployeeDal());
        public IViewComponentResult Invoke()
        {
            var values = employeeManager.TGetList();
            return View(values);
        }
    }
}