using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Lecture.Web.Models;

namespace Lecture.Web.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string connectionString;
        public CitySqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public IList<City> GetCities(string countryCode)
        {
            IList<City> cities = new List<City>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM city WHERE countryCode=@countryCode", conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var city = new City()
                        {
                            CityId = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            CountryCode = Convert.ToString(reader["countrycode"]),
                            District = Convert.ToString(reader["district"]),
                            Population = Convert.ToInt32(reader["population"])
                        };

                        cities.Add(city);
                    }
                }
            }
            catch (SqlException ex)
            {
                throw;
            }

            return cities;
        }

        public IList<City> GetCities(string countryCode, string district)
        {
            district = "%" + district + "%";

            var output = new List<City>();

            try
            {
                // Create a new connection object
                using (var conn = new SqlConnection(connectionString))
                {
                    // Open the connection
                    conn.Open();

                    var sql = $"SELECT * FROM city WHERE countryCode = @countryCode AND district LIKE @district";
                    var cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@countryCode", countryCode);
                    cmd.Parameters.AddWithValue("@district", district);

                    // Execute the command
                    var reader = cmd.ExecuteReader();

                    // Loop through each row
                    while (reader.Read())
                    {
                        // Create a city
                        var city = new City();
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

        public void AddCity(City city)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("INSERT INTO city VALUES (@name, @countryCode, @district, @population);", conn);
                    cmd.Parameters.AddWithValue("@name", city.Name);
                    cmd.Parameters.AddWithValue("@countryCode", city.CountryCode);
                    cmd.Parameters.AddWithValue("@district", city.District);
                    cmd.Parameters.AddWithValue("@population", city.Population);

                    cmd.ExecuteNonQuery();
                }
            }
            catch(SqlException ex)
            {
                throw;
            }
        }

    }
}
