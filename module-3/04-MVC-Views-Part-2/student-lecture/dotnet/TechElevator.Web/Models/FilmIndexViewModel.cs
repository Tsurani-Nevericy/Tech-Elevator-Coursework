using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class FilmIndexViewModel
    {
        public IList<Film> Films { get; set; }
        public int Age { get; set; }
        public int Height { get; set; }
    }
}
