using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.DAL;

using Microsoft.AspNetCore.Mvc;

namespace Lecture.Web.Controllers
{
    public class WorldController : Controller
    {
        private ICountryDAO countryDAL;
        private ICityDAO cityDAL;

        public WorldController(ICountryDAO countryDAL, ICityDAO cityDAL)
        {
            this.countryDAL = countryDAL;
            this.cityDAL = cityDAL;
        }


        // 1. Create WorldController / Index action so that user can 
        //      navigate to /world OR /world/index
        public IActionResult Index()
        {
            //5. Call the DAL 
            //var countryDAL = new CountrySqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=world;Integrated Security=true;");            
            var countries = countryDAL.GetCountries(); 

            //6. Pass the model into the view
            return View(countries);
        }

        // 8. Create an action CitiesByCountry so that the user can
        // navigate to world/citiesbycountry
        public IActionResult CitiesByCountry(string code)
        {
            //10. Call the DAL
            //var cityDAL = new CitySqlDAL(@"Data Source=.\sqlexpress;Initial Catalog=world;Integrated Security=true;");
            var cities = cityDAL.GetCities(code);

            //11. Pass the model into the view
            return View(cities);
        }
    }
}