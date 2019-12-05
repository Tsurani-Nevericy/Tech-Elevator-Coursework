using Lecture.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.DAL
{
    public interface ICountryDAO
    {
        IList<Country> GetCountries();
    }
}
