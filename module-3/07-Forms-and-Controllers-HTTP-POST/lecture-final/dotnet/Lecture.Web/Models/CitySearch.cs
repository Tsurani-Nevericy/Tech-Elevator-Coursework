using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    //6. Create a model that holds values that are going to be used in our form.
    public class CitySearch
    {
        /// <summary>
        /// The country code to search by.
        /// </summary>
        [Display(Name = "Enter a country code")]
        public string CountryCode { get; set; }

        /// <summary>
        /// The district that is used to filter data.
        /// </summary>
        [Display(Name = "Enter a district")]
        public string District { get; set; }

        /// <summary>
        /// The results that match the search criteria.
        /// </summary>
        public IList<City> Results { get; set; }
    }
}
