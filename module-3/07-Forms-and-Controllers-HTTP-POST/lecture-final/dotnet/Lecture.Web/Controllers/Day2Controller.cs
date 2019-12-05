using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.DAL;
using Lecture.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Web.Controllers
{
    public class Day2Controller : Controller
    {
        //8. Inject an ICityDAO controller.
        private ICityDAO cityDao;
        public Day2Controller(ICityDAO cityDao)
        {
            this.cityDao = cityDao;
        }

        //1. Create an action allowing user to nav to day2/addcity
        [HttpGet]
        public IActionResult AddCity()
        {
            // 6. Create a city model and pass it into the empty form view.
            City city = new City();
            return View(city);
        }

        //3. Create an action that handles POST requests to day2/addcity
        [HttpPost]
        [ValidateAntiForgeryToken] //11. Validate the forgery token to prevent a Cross-site request forgery (CSRF) attack
        public IActionResult AddCity(City city)
        {
            //9. Save the city into our DAL
            cityDao.AddCity(city);

            //4. Redirect user to the Confirmation Action
            //return RedirectToAction("Confirmation");

            //10. Redirect the user to the "Search Result page" showing cities in the district they used
            return RedirectToAction("SearchResult", "Day1", new { CountryCode = city.CountryCode, District = city.District });
        }

        //5. Create an action allowing user to nav to day2/confirmation
        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }
    }
}