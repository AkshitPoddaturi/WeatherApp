using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        public ActionResult Index()
        {
            return View();
        }

        // POST: Default/Login
        [HttpPost]
        public ActionResult Index(user_controller model)
        {
            // Perform login check here. For simplicity, we'll assume login is always successful
            if (ModelState.IsValid)
            {
                // Redirect to weather search page after login
                return RedirectToAction("SearchWeather", "Weather");
            }

            return View(model);
        }
    }
}