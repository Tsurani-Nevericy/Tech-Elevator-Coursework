using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CalculatorModel
    {
        public double NumberToConvert { get; set; }
        public string StartingUnit { get; set; }
        public string EndingUnit { get; set; }

        public double GetConvertedValue()
        {
            // pick a base unit to convert everything to
            Dictionary<string, double> conversionToFeetValues = new Dictionary<string, double>()
            {
                {"ft", 1 },
                {"in", 0.08333 },
                {"cm", 0.0328084 },
                {"mi", 5280}
            };

            double valueInFeet = NumberToConvert * conversionToFeetValues[StartingUnit];
            double endingValue = valueInFeet / conversionToFeetValues[EndingUnit];

            return endingValue;
        }


        public static List<SelectListItem> Units = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "ft", Value = "ft" },
            new SelectListItem() { Text = "in", Value = "in" },
            new SelectListItem() { Text = "cm", Value = "cm" },
            new SelectListItem() { Text = "mi", Value = "mi" }
        };
    }
}
