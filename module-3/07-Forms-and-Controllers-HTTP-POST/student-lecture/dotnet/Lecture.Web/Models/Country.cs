using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    //3. Create the country model
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string HeadOfState { get; set; }
    }
}
