using GETForms.Web.Models;
using System.Collections.Generic;

namespace GETForms.Web.DAL
{
    public interface ICustomerDAO
    {
        /// <summary>
        /// Searches for customers.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        IList<Customer> SearchForCustomers(string search, string sortBy);
    }
}