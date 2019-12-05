using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;

namespace TechElevator.Web.Controllers
{
    public class FilmsController : Controller
    {
        // films/index
        public IActionResult Index()
        {
            IStarWarsDAL dal = new StarWarsDAL();
            var films = dal.GetFilms();

            return View(films);
        }

        //films/filmdetails/{id}
        //films/filmdetails?id={id}
        public IActionResult Detail(string id)
        {
            IStarWarsDAL dal = new StarWarsDAL();
            var film = dal.GetFilm(id);

            if (film == null)
            {
                return NotFound();
            }
            else
            {
                return View(film);
            }
        }
    }
}