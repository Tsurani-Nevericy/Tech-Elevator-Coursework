using TechElevator.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.DAL
{
    public interface IStarWarsDAL
    {
        /// <summary>
        /// Returns all of the films.
        /// </summary>
        /// <returns></returns>
        IList<Film> GetFilms();

        /// <summary>
        /// Returns a single film
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Film GetFilm(string id);        
    }
}
