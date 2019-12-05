using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public interface ICityDAO
    {
        IList<City> GetCities();
        IList<City> GetCities(string countryCode, string district);
        IList<string> GetCountryCodes();
        void AddCity(City city);
    }
}
