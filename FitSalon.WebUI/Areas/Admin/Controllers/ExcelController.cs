using ClosedXML.Excel;
using FitSalon.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using FitSalon.WebUI.Models;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]

    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<ServiceModel> ServiceList()
        {
            List<ServiceModel> _serviceModels = new List<ServiceModel>();
            using (var c = new Context())
            {
                _serviceModels = c.Services.Select(x => new ServiceModel
                {
                    City = x.City,
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity = x.Capacity
                }).ToList();
                return _serviceModels;
            }
        }

        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var worksheet = excel.Workbook.Worksheets.Add("Sayfa1");
            worksheet.Cells[1, 1].Value = "İşletmeler";
            worksheet.Cells[1, 2].Value = "Çalışanlar";
            worksheet.Cells[1, 3].Value = "Kontenjan";

            worksheet.Cells[2, 1].Value = "Fitshape + Diyet";
            worksheet.Cells[2, 2].Value = "Enes Mert Kaya";
            worksheet.Cells[2, 2].Value = "50";

            worksheet.Cells[3, 1].Value = "EMS Seansları";
            worksheet.Cells[3, 2].Value = "Burçin Yücel";
            worksheet.Cells[3, 2].Value = "35";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Statik.xlsx");
        }

        public IActionResult ServiceExcelReport()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("İşletme Listesi");
                worksheet.Cell(1, 1).Value = "Şehir";
                worksheet.Cell(1, 2).Value = "Süre";
                worksheet.Cell(1, 3).Value = "Fiyat";
                worksheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;
                foreach (var item in ServiceList())
                {
                    worksheet.Cell(rowCount, 1).Value = item.City;
                    worksheet.Cell(rowCount, 2).Value = item.DayNight;
                    worksheet.Cell(rowCount, 3).Value = item.Price;
                    worksheet.Cell(rowCount, 4).Value = item.Capacity;
                    rowCount++;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "DinamikRotaListesi.xlsx");
                }
            }
        }
    }
}
