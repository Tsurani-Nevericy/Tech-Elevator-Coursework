using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CityDetailViewModel
    {
        public IList<City> Cities { get; set; }
        public CityListViewModel CityListVM { get; set; }
    }
}
