using FitSalon.BusinessLayer.Abstract;
using FitSalon.EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitSalon.WebUI.Models;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CityController : Controller
    {
        private readonly IServiceService _serviceService;

        public CityController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CityList()
        {
            var jsonCity = JsonConvert.SerializeObject(_serviceService.TGetList());
            return Json(jsonCity);
        }

        [HttpPost]
        public IActionResult AddCityDestination(Service service)
        {
            service.Status = true;
            _serviceService.TInsert(service);
            var values = JsonConvert.SerializeObject(service);
            return Json(values);
        }

        public IActionResult GetById(int ServiceID)
        {
            var values = _serviceService.TGetByID(ServiceID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);
        }

        public IActionResult DeleteCity(int id)
        {
            var values = _serviceService.TGetByID(id);
            _serviceService.TDelete(values);
            return NoContent();
        }

        public IActionResult UpdateCity(Service service)
        {
            _serviceService.TUpdate(service);
            var v = JsonConvert.SerializeObject(service);
            return Json(v);
        }

        //public static List<CityClass> cities = new List<CityClass>
        //{
        //    new CityClass
        //    {
        //        CityID=1,
        //        CityName="Üsküp",
        //        CityCountry="Makedonya"
        //    },
        //    new CityClass
        //    {
        //        CityID=2,
        //        CityName="Roma",
        //        CityCountry="İtalya"
        //    },
        //    new CityClass
        //    {
        //        CityID=3,
        //        CityName="Londra",
        //        CityCountry="İngiltere"
        //    }
        //};


    }
}
