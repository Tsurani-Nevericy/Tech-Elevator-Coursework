using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SessionCart.Web.Models
{
    public class Product
    {
        /// <summary>
        /// Product's id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product's name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Product's cost.
        /// </summary>
        public decimal Cost { get; set; }

    }
}
