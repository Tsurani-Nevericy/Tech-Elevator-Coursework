using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// Database model for the site table
    /// </summary>
    public class SiteItem : BaseItem
    {
        /// <summary>
        /// Foreign key for the campground table
        /// </summary>
        public int CampgroundId { get; set; } = BaseItem.InvalidId;

        /// <summary>
        /// The number designator for the campsite
        /// </summary>
        public int SiteNumber { get; set; }

        /// <summary>
        /// The site maximum occupancy
        /// </summary>
        public int MaxOccupancy { get; set; }

        /// <summary>
        /// Specifies if the site is handicap accessible
        /// </summary>
        public bool IsAccessible { get; set; }

        /// <summary>
        /// The maximum rv length for the site
        /// </summary>
        public int MaxRvLength { get; set; }

        /// <summary>
        /// Specifies if the site has utilities
        /// </summary>
        public bool HasUtilities { get; set; }

        /// <summary>
        /// Creates a site info object from this site item
        /// </summary>
        /// <param name="dailyFee">The site daily fee</param>
        /// <param name="campgroundName">The campground name the site is in</param>
        /// <returns>A new populated site info object</returns>
        public SiteInfo CreateSiteInfo(decimal dailyFee, string campgroundName)
        {
            return new SiteInfo()
            {
                Site = this,
                DailyFee = dailyFee,
                Name = campgroundName
            };
        }
    }
}
