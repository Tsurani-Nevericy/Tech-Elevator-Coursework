using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class City
    {
        public int CityId { get;  set; }

        [Display(Name = "Name:")]
        [Required(ErrorMessage="Elizabeth says NO")]
        public string Name { get;  set; }

        [CountryCode]
        public string CountryCode { get;  set; }

        [Required]
        public string District { get;  set; }

        [Range(1, 1000)]
        public int Population { get;  set; }
    }
}
