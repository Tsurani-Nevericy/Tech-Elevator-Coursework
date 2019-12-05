using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCModels.Web.Models
{
    /// <summary>
    /// Sorting options for displaying products.
    /// </summary>
    public enum ProductSortOrder
    {
        Default,
        PriceLowToHigh,
        PriceHighToLow,
        RatingHighToLow
    }
}