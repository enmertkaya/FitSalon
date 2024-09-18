using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using FitSalon.WebUI.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace FitSalon.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class APIMovieController : Controller
    {
        public async Task<IActionResult> Index()
        {
            APIMovieViewModel weather = new APIMovieViewModel();
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://open-weather13.p.rapidapi.com/city/istanbul/TR"),
                Headers =
                {
                    { "x-rapidapi-key", "a87e92a2f9msh6806a9acff11590p1c7dbbjsn31fbdd15a414" },
                    { "x-rapidapi-host", "open-weather13.p.rapidapi.com" },
                },
            };

            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var weatherData = JsonConvert.DeserializeObject<dynamic>(body);

                weather.City = weatherData.name;
                weather.Temperature = weatherData.main.temp + " °C";
                weather.WeatherDescription = weatherData.weather[0].description;
                weather.Icon = "http://openweathermap.org/img/w/" + weatherData.weather[0].icon + ".png";

                return View(weather);
            }
        }
    }
}
