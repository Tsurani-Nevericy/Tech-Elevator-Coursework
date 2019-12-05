using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class ActorViewModel
    {
        public string LastName { get; set; }
        public IList<Actor> Actors { get; set; } = new List<Actor>();

    }
}
