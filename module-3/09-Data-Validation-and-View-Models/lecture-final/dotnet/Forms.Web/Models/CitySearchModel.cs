using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    //4. Create a model that will be used by the form.
    public class CitySearchModel
    {
        /// <summary>
        /// The country code to search for.
        /// </summary>
        [Display(Name = "Enter a country code")]        
        public string CountryCode { get; set; }

        /// <summary>
        /// The district to filter cities by.
        /// </summary>
        [Display(Name = "Enter a district")]
        public string District { get; set; }

        /// <summary>
        /// The results that matched the criteria.
        /// </summary>
        public IList<City> Results { get; set; }
    }
}
