using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CityListViewModel
    {
        public string CountryCode { get; set; }
        public string District { get; set; }

        public List<SelectListItem> CountryCodes { get; set; } = new List<SelectListItem>();
    }
}
