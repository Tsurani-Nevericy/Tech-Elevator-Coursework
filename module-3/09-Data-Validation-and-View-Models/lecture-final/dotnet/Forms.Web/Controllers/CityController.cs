using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forms.Web.DAL;
using Forms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Forms.Web.Controllers
{
    public class CityController : Controller
    {
        private ICityDAO cityDao;

        public CityController(ICityDAO cityDao)
        {
            this.cityDao = cityDao;
        }

        /// <summary>
        /// Represents the index listing of cities.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            // Get all of the cities
            var cities = cityDao.GetCities();

            // Return the Index view
            return View(cities);
        }

        // GET city/new
        /// <summary>
        /// Represents an empty new city action.
        /// </summary>
        /// <returns></returns>
        [HttpGet]        
        public IActionResult New()
        {            
            // Return the empty view
            return View();
        }

        /// <summary>
        /// Represents a save city action.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(City city)
        {
            // Are there errors
            if (!ModelState.IsValid)
            {
                // Return the new view again
                return View(city);
            }
            else
            {
                // Save the City
                cityDao.AddCity(city);

                // Redirect the user to City/Index Action
                return RedirectToAction("index", "city");
            }
        }
    }
}
