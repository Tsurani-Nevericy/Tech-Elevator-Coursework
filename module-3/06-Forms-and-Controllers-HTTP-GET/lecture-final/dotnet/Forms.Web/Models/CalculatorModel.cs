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
        /// <summary>
        /// The number to convert.
        /// </summary>
        [Display(Name = "Number")]
        public double NumberToConvert { get; set; }

        /// <summary>
        /// The unit to convert from.
        /// </summary>
        [Display(Name = "Starting Unit")] 
        public string StartingUnit { get; set; }

        /// <summary>
        /// The unit to convert to.
        /// </summary>
        [Display(Name = "Ending Unit")]
        public string EndingUnit { get; set; }

        /// <summary>
        /// Calculators a converted value assuming a Starting Unit and Ending Unit
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Provides the list of Units for conversion.
        /// </summary>
        public static List<SelectListItem> Units = new List<SelectListItem>()
        {
            new SelectListItem() { Text = "Feet", Value = "ft" },
            new SelectListItem() { Text = "Inches", Value = "in" },
            new SelectListItem() { Text = "Centimeters", Value = "cm" },
            new SelectListItem() { Text = "Miles", Value = "mi" }
        };
    }
}
