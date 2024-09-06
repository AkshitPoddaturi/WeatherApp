using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using WeatherApp.Models;
using System.Configuration;


namespace WeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        // GET: Weather
        public ActionResult SearchWeather()
        {
            return View();
        }

        // POST: Weather/GetWeather
        [HttpPost]
        public async Task<ActionResult> GetWeather(string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                ViewBag.Message = "Please enter a city name.";
                return View("SearchWeather");
            }

            // OpenWeather API key
            //string apiKey = ConfigurationManager.AppSettings["OpenWeatherApiKey"];
            string apiKey = "e269c9a9e984b652d86219dd61354731";
            string apiUrl = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric";

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(apiUrl);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    var weatherInfo = JsonConvert.DeserializeObject<WeatherResponse>(data);

                    // Pass the weather data to the view
                    return View("WeatherResult", weatherInfo);
                }
                else
                {
                    ViewBag.Message = "Error fetching weather data. Please try again.";
                    return View("SearchWeather");
                }
            }
        }
    }
}