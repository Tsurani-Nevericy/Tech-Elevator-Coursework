using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class FilmsController : Controller
    {
        private IFilmDAO _db = null;

        public FilmsController(IFilmDAO db)
        {
            _db = db;
        }
        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new FilmViewModel());
        }

        /// <summary>
        /// Receives the search result request and goes to th database looking for the information.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public ActionResult SearchResult(string genre, int MinimumLength, int MaximumLength/*FilmSearch request */)
        {
            /* Call the DAL and pass the values as a model back to the View */
            IList<Film> films = _db.GetFilmsBetween(genre, MinimumLength, MaximumLength); //FindActors(lastName); //SearchForCustomers(search, sortBy);

            FilmViewModel vm = new FilmViewModel();
            vm.Films = _db.GetFilmsBetween(genre, MinimumLength, MaximumLength);//.Actors = _db.FindActors(lastName);

            return View("Index", vm);
        }
    }
}