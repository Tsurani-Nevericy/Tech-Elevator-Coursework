using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.Models;

namespace Lecture.Web.DAL
{
    public class CountrySqlDAO : ICountryDAO
    {
        private string connectionString;
        public CountrySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        //4. Create DAL method to get all countries
        public IList<Country> GetCountries()
        {
            IList<Country> countries = new List<Country>();

            try
            {
                using(SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM country;", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Country country = new Country()
                        {
                            Code = Convert.ToString(reader["code"]),
                            Name = Convert.ToString(reader["name"]),
                            Continent = Convert.ToString(reader["continent"]),
                            HeadOfState = Convert.ToString(reader["headofstate"])
                        };
                        countries.Add(country);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return countries;
        }
    }
}
