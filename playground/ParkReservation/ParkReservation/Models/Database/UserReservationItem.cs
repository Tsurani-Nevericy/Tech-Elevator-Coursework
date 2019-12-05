using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// The database table for the user reservation table. Links the user and reservation tables.
    /// </summary>
    public class UserReservationItem : BaseItem
    {
        /// <summary>
        /// The foreign key to the user table. This is the user that made the reservation.
        /// </summary>
        public int UserId { get; set; } = BaseItem.InvalidId;

        /// <summary>
        /// The foreign key to the reservation table. This is the reservation that was made.
        /// </summary>
        public int ReservationId { get; set; }
    }
}
