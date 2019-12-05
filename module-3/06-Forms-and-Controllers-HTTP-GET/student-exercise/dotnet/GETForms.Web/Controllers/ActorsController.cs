using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class ActorsController : Controller
    {
        private IActorDAO _db = null;

        public ActorsController(IActorDAO db)
        {
            _db = db;
        }
        /// <summary>
        /// The request to display an empty search page.
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(new ActorViewModel());
        }

        /// <summary>
        /// The request to display search results.
        /// </summary>
        /// <param name="request">A request model that contains the search parameters.</param>
        /// <returns></returns>
        public ActionResult SearchResult(/*ActorSearch request */string lastName)
        {
            /* Call the DAL and pass the values as a model back to the View */
            IList<Actor> actors = _db.FindActors(lastName); //SearchForCustomers(search, sortBy);

            ActorViewModel vm = new ActorViewModel();
            vm.Actors = _db.FindActors(lastName);

            return View("Index", vm);
        }
    }
}