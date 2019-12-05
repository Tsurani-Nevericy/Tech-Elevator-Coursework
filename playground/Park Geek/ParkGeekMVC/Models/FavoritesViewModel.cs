using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkGeekMVC.Models
{
    public class FavoritesViewModel
    {
        public string ParkCode { get; set; }
        public int NumVotes { get; set; }
        public string ParkName { get; set; }
        public string ParkDescription { get; set; }
    }
}
