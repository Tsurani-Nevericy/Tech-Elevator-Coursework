using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class Customer
    {
        /// <summary>
        /// The customer's first name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// The customer's last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// The customer's email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// The customer's active status
        /// </summary>
        public bool IsActive { get; set; }
    }
}
