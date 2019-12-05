using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.DAL;
using Lecture.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lecture.Web.Controllers
{
    public class Day1Controller : Controller
    {
        //10. Inject the ICityDAL into the controller
        private ICityDAO dao;
        public Day1Controller(ICityDAO dao)
        {
            this.dao = dao;
        }

        //1. Allow user to navigate to day1/index OR day1
        //   by creating an Index action.
        public IActionResult Index()
        {
            //7. Pass a city search model into the index view.
            var citySearch = new CitySearch();
            return View(citySearch);
        }


        //4. Allow the user to navigate to day1/searchresult
        //   by creating a search result action.
                                            //9. Have the model passed in to the result action
        public IActionResult SearchResult(CitySearch citySearch)
        {
            //11. Call the DAL to get matching cities
            var cities = dao.GetCities(citySearch.CountryCode, citySearch.District);

            //12. Pass the cities into the view
            citySearch.Results = cities;

            return View(citySearch);
        }


        // CALCULATOR EXAMPLE
        // a. Create a calculator page that displays the form fields
        public IActionResult Calculator()
        {
            //e. pass the model into the view
            var calculator = new Calculator();

            return View(calculator);
        }

        // c. Create the calculator result action to display calculated data.
                                            //f. pass the model into the second action
        public IActionResult CalculatorResult(Calculator calculator)
        {
            return View(calculator);
        }
    }
}