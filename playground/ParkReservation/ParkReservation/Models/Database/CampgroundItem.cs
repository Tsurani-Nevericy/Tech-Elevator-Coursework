using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// Database model for the campground table
    /// </summary>
    public class CampgroundItem : BaseItem
    {
        /// <summary>
        /// Foreign key to the park table
        /// </summary>
        public int ParkId { get; set; } = BaseItem.InvalidId;

        /// <summary>
        /// Campground name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The month the campground is open (1-12)
        /// </summary>
        public int OpenFromMonth { get; set; }

        /// <summary>
        /// The month the campground is closed (1-12)
        /// </summary>
        public int OpenToMonth { get; set; }

        /// <summary>
        /// The daily fee to stay in this campground
        /// </summary>
        public decimal DailyFee { get; set; }
    }
}
