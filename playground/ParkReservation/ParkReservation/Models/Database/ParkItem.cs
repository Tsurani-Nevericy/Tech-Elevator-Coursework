using Security.Models.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkReservation.Models.Database
{
    /// <summary>
    /// Database model for the park table
    /// </summary>
    public class ParkItem : BaseItem
    {
        /// <summary>
        /// Park name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Park location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// The date the park was established
        /// </summary>
        public DateTime EstablishedDate { get; set; }

        /// <summary>
        /// The amount of space the park takes up
        /// </summary>
        public int Area { get; set; }

        /// <summary>
        /// How many visitors the park has had to date
        /// </summary>
        public int Visitors { get; set; }

        /// <summary>
        /// Desription of the park
        /// </summary>
        public string Description { get; set; }
    }
}
