using Lecture.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.DAL
{
    public interface ICityDAO
    {
        IList<City> GetCities(string countryCode);
        IList<City> GetCities(string countryCode, string district);
        void AddCity(City city);
    }
}
