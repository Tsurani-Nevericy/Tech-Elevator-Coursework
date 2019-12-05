using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.Models
{
    public class ProductFilter
    {
        /// <summary>
        /// The minimum price filter.
        /// </summary>
        public decimal MinPrice { get; set; } = 0;

        /// <summary>
        /// The maximum price filter.
        /// </summary>
        public decimal MaxPrice { get; set; } = decimal.MaxValue;

        /// <summary>
        /// The minimum rating filter.
        /// </summary>
        public int MinRating { get; set; } = 0;

        /// <summary>
        /// The category to filter.
        /// </summary>
        public string Category { get; set; } = "";
    }
}
