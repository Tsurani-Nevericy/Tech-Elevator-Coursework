using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models
{
    /// <summary>
    /// This holds the information needed to do a filtered search for available campsites
    /// </summary>
    public class ReservationInfo
    {
        /// <summary>
        /// The start date for the reservation
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// The end date of the reservation
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// The foreign key to the campground the reservation should be made in
        /// </summary>
        public int CampgroundId { get; set; } = BaseItem.InvalidId;

        /// <summary>
        /// Specifies the occupancy requirement of the reservation
        /// </summary>
        public int Occupancy { get; set; }

        /// <summary>
        /// Specifies if the site needs to be handicap accessible
        /// </summary>
        public bool IsAccessible { get; set; }

        /// <summary>
        /// Specifies the required rv length minimum for the reservation
        /// </summary>
        public int RvLength { get; set; }

        /// <summary>
        /// Specifies if utilities are required for the campsite
        /// </summary>
        public bool HasUtilities { get; set; }
    }
}
