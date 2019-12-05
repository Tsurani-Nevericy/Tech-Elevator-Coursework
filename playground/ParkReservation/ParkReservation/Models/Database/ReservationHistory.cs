using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// Model for holding a reservation item and the campground the reservation is for
    /// </summary>
    public class ReservationHistory
    {
        /// <summary>
        /// The database reservation table item
        /// </summary>
        public ReservationItem Reservation { get; set; } = new ReservationItem();

        /// <summary>
        /// The name of the campground the reservation was made in
        /// </summary>
        public string CampgroundName { get; set; }
    }
}
