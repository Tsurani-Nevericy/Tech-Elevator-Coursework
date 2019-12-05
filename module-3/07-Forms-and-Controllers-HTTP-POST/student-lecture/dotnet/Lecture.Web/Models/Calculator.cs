using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lecture.Web.Models
{
    // d. Create our input model
    public class Calculator
    {
        // THE FORM FIELDS
        /// <summary>
        /// The number we want to convert.
        /// </summary>
        public double NumberToConvert { get; set; }

        /// <summary>
        /// The starting unit to convert from.
        /// </summary>
        public string StartingUnit { get; set; }

        /// <summary>
        /// The ending unit to convert from.
        /// </summary>
        public string EndingUnit { get; set; }

        // THE LOGIC
        /// <summary>
        /// Returns a calculated conversion from starting unit to ending unit.
        /// </summary>
        /// <returns></returns>
        public double GetConvertedValue()
        {
            Dictionary<string, double> conversions = new Dictionary<string, double>()
            {
                {"ft", 1 },
                {"in", 0.08333 },
                {"cm", 0.0328084 },
                {"mi", 5280 }
            };

            double valueInFeet = NumberToConvert * conversions[StartingUnit];
            double endingValue = valueInFeet / conversions[EndingUnit];
            return endingValue;
        }


        // ALL OF THE CHOICES TO PICK FROM
        public static IList<SelectListItem> Units = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "feet", Value = "ft" },
            new SelectListItem() { Text = "inches", Value = "in" },
            new SelectListItem() { Text = "centimeters", Value = "cm" },
            new SelectListItem() { Text = "miles", Value = "mi" }
        };
    }
}
