using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// Database model for the reservation table
    /// </summary>
    public class ReservationItem : BaseItem
    {
        /// <summary>
        /// The foreign key for the site table
        /// </summary>
        public int SiteId { get; set; } = BaseItem.InvalidId;

        /// <summary>
        /// The reservation name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The start date of the reservation
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// The end date of the reservation
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// The date the reservation was created
        /// </summary>
        public DateTime CreatedDate { get; set; }
    }
}
