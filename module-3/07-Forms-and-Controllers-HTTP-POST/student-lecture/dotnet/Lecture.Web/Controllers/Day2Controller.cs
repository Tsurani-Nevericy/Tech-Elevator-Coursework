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
        private ICityDAO _db = null;

        public Day2Controller(ICityDAO db)
        {
            _db = db;
        }

        // /day2/AddCity
        [HttpGet]
        public IActionResult AddCity()
        {
            return View("AddCity");
        }

        // /day2/AddCity
        [HttpPost]
        public IActionResult AddCity(City city)
        {
            IActionResult result = null;

            try
            {
                _db.AddCity(city);
                result = RedirectToAction("Results", new { Name = city.Name });
            }
            catch(Exception)
            {
                result = RedirectToAction("Results", new { Name = city.Name, Error = "Failed" });
            }

            return result;
        }

        // /day2/Results
        [HttpGet]
        public IActionResult Results(Day2SuccessViewModel vm)
        {
            return View("Success", vm);
        }

    }
}