using ParkReservation.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models
{
    /// <summary>
    /// Holds information about the camp site
    /// </summary>
    public class SiteInfo
    {
        /// <summary>
        /// The record from the site table
        /// </summary>
        public SiteItem Site { get; set; }

        /// <summary>
        /// The daily fee for the campground the site belongs to
        /// </summary>
        public decimal DailyFee { get; set; }

        /// <summary>
        /// The name of the campround the site belongs to
        /// </summary>
        public string Name { get; set; }
    }
}
