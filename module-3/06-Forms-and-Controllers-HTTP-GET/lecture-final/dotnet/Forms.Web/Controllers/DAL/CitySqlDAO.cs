using Forms.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private readonly string connectionString;

        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns all of the cities.
        /// </summary>
        /// <returns></returns>
        public IList<City> GetCities()
        {
            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    string sql = $"SELECT * FROM city order by id desc";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        City city = new City();
                        city.CityId = Convert.ToInt32(reader["id"]);
                        city.Name = Convert.ToString(reader["name"]);
                        city.CountryCode = Convert.ToString(reader["countrycode"]);
                        city.District = Convert.ToString(reader["district"]);
                        city.Population = Convert.ToInt32(reader["population"]);

                        output.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return output;
        }

        public IList<City> GetCities(string countryCode, string district)
        {
            district = "%" + district + "%";

            List<City> output = new List<City>();

            try
            {
                // Create a new connection object
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();
                 
                    string sql = $"SELECT * FROM city WHERE countryCode = @countryCode AND district LIKE @district";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);
                    cmd.Parameters.AddWithValue("@district", district);

                    // Execute the command
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        City city = new City();
                        city.CityId = Convert.ToInt32(reader["id"]);
                        city.Name = Convert.ToString(reader["name"]);
                        city.CountryCode = Convert.ToString(reader["countrycode"]);
                        city.District = Convert.ToString(reader["district"]);
                        city.Population = Convert.ToInt32(reader["population"]);

                        output.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            return output;
        }

        /// <summary>
        /// Returns all of the country codes.
        /// </summary>
        /// <returns></returns>
        public IList<string> GetCountryCodes()
        {
            List<string> countryCodes = new List<string>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = "SELECT code FROM country;";
                    SqlCommand cmd = new SqlCommand(sql, conn);

                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        countryCodes.Add(Convert.ToString(reader["code"]));
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return countryCodes;
        }

        /// <summary>
        /// Adds a city to the database.
        /// </summary>
        /// <param name="city"></param>
        public void AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string sql = $"INSERT INTO city VALUES (@name, @countryCode, @district, @population);";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
    }
}
