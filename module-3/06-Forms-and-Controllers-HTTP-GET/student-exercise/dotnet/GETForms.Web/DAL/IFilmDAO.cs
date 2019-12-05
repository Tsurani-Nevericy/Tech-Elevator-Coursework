using GETForms.Web.Models;
using System.Collections.Generic;

namespace GETForms.Web.DAL
{
    public interface IFilmDAO
    {
        /// <summary>
        /// Searches for films within the given parameters.
        /// </summary>
        /// <param name="genre"></param>
        /// <param name="minLength"></param>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        IList<Film> GetFilmsBetween(string genre, int minLength, int maxLength);

        /// <summary>
        /// Searches for the list of all possible genres
        /// </summary>
        /// <returns></returns>
        IList<string> GetGenres();
    }
}