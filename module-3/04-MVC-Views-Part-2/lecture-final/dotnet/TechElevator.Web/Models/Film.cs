using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class Film
    {
        public string Name { get; set; }        
        public string ImageUrl { get; set; }
        public int Length { get; set; }
        public int YearReleased { get; set; }
        public string Id { get; set; }
    }
}
