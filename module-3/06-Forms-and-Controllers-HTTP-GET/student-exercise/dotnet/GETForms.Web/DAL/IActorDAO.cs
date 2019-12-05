using GETForms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.DAL
{
    public interface IActorDAO
    {
        /// <summary>
        /// Returns a list of actors by last name search.
        /// </summary>
        /// <param name="lastNameSearch"></param>
        /// <returns></returns>
        IList<Actor> FindActors(string lastNameSearch);
    }
}
