using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Index()
        {
            var db = new MockStarWarsDAO();
            var vm = new FilmIndexViewModel();
            vm.Films = db.GetFilms();
            //vm.Age = 18;
            //vm.Height = 74;

            return View(vm);
        }

        public IActionResult Detail(string id)
        {
            IActionResult result = null;

            Film film = null;
            if (id != null)
            {
                var db = new MockStarWarsDAO();
                film = db.GetFilm(id);
                result = View(film);
            }
            else
            {
                result = View("Error");
            }

            return result;
        }
    }
}