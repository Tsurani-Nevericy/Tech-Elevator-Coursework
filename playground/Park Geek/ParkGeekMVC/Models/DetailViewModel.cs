using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkGeekMVC.Models
{
    public class DetailViewModel
    {
        public string ParkCode { get; set; }
        public string ParkName { get; set; }
        public string State { get; set; }
        public int Acreage { get; set; }
        public int Elevation { get; set; }
        public int MilesOfTrail { get; set; }
        public int NumberOfSites { get; set; }
        public string Climate { get; set; }
        public int YearFounded { get; set; }
        public int AnnualVisitors { get; set; }
        public string InspirationalQuote { get; set; }
        public string QuoteSource { get; set; }
        public string ParkDescription { get; set; }
        public int EntryFee { get; set; }
        public int NumAnimalSpecies { get; set; }

        public string Weather { get; set; }
        public Dictionary<string, Dictionary<string, string>> WeatherData { get; set; } = new Dictionary<string, Dictionary<string, string>>();
    }
}
