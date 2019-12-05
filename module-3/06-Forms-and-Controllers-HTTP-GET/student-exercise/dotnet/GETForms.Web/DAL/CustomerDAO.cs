using GETForms.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.DAL
{
    public class CustomerDAO : ICustomerDAO
    {
        private string connectionString;

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Searches for customers.
        /// </summary>
        /// <param name="search"></param>
        /// <param name="sortBy"></param>
        /// <returns></returns>
        public IList<Customer> SearchForCustomers(string search, string sortBy)
        {
            IList<Customer> result = new List<Customer>();

            string sql = "select * from customer where last_name like @search or first_name like @search order by "+sortBy;
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@search", $"%{search}%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = new Customer();
                    customer.Email = Convert.ToString(reader["email"]);
                    customer.FirstName = Convert.ToString(reader["first_name"]);
                    customer.LastName = Convert.ToString(reader["last_name"]);
                    customer.IsActive = Convert.ToBoolean(reader["active"]);
                    result.Add(customer);
                }
                return result;
            }
        }
    }
}
