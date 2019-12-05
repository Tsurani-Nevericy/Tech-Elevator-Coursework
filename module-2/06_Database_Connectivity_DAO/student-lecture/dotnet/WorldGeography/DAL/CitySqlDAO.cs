using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class CitySqlDAO : ICityDAO
    {
        private string _connectionString;
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";

        /// <summary>
        /// Creates a new sql-based city dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public CitySqlDAO(string databaseConnectionString)
        {
            _connectionString = databaseConnectionString;
        }

        public int AddCity(City city)
        {
            int result = 0;

            // Create a SQL string
            const string sql = "INSERT city (name, countrycode, district, population) " +
                               "VALUES (@name, @countrycode, @district, @population);";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);

                // Insert parameters in command object
                cmd.Parameters.AddWithValue("@name", city.Name);
                cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                cmd.Parameters.AddWithValue("@district", city.District);
                cmd.Parameters.AddWithValue("@population", city.Population);

                // Execute command object
                result = (int)cmd.ExecuteScalar();
            }

            return result;
        }

        public IList<City> GetCitiesByCountryCode(string countryCode)
        {
            var result = new List<City>();

            // Create a SQL string
            const string sql = "SELECT * From city WHERE countrycode = @countryCode;";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Insert parameters in command object
                cmd.Parameters.AddWithValue("@countryCode", countryCode);

                // Execute command object
                SqlDataReader reader = cmd.ExecuteReader();

                // If it was a Select then parse the result set into objects
                while (reader.Read())
                {
                    // Create a new object
                    City city = GetCityFromReader(reader);

                    // Add object to List if more than one row retured
                    result.Add(city);
                }                
            }

            // Return new objects
            return result;
        }

        private City GetCityFromReader(SqlDataReader reader)
        {
            // Create a new object
            City city = new City();

            // Copy data from result set row into object
            city.CityId = Convert.ToInt32(reader["id"]);
            city.CountryCode = Convert.ToString(reader["countrycode"]);
            city.District = Convert.ToString(reader["district"]);
            city.Name = Convert.ToString(reader["name"]);
            city.Population = Convert.ToInt32(reader["population"]);

            return city;
        }

        public void UpdateCity(City city)
        {
            // Create a SQL string
            const string sql = "UPDATE city SET name = @name, " +
                               "countrycode = @countrycode, " +
                               "district = @district, " +
                               "population = @population " +
                               "WHERE id = @id;";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Insert parameters in command object
                cmd.Parameters.AddWithValue("@name", city.Name);
                cmd.Parameters.AddWithValue("@countrycode", city.CountryCode);
                cmd.Parameters.AddWithValue("@district", city.District);
                cmd.Parameters.AddWithValue("@population", city.Population);
                cmd.Parameters.AddWithValue("@id", city.CityId);

                // Execute command object
                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Failed to update the city record.");
                }
            }
        }

    }
}
