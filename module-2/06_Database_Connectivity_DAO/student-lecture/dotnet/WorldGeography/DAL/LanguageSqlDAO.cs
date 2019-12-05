using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldGeography.Models;

namespace WorldGeography.DAL
{
    public class LanguageSqlDAO : ILanguageDAO
    {
        private string _connectionString;

        /// <summary>
        /// Creates a sql based language dao.
        /// </summary>
        /// <param name="databaseConnectionString"></param>
        public LanguageSqlDAO(string databaseConnectionString)
        {
            _connectionString = databaseConnectionString;
        }

        public IList<Language> GetLanguages(string countryCode)
        {
            throw new NotImplementedException();
        }

        public bool AddNewLanguage(Language newLanguage)
        {
            throw new NotImplementedException();
        }

        public void RemoveLanguage(Language deadLanguage)
        {
            // Create a SQL string
            const string sql = "DELETE FROM countrylanguage WHERE language = @language AND countrycode = @countrycode;";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Insert parameters in command object
                cmd.Parameters.AddWithValue("@language", deadLanguage.Name);
                cmd.Parameters.AddWithValue("@countrycode", deadLanguage.CountryCode);

                // Execute command object
                if (cmd.ExecuteNonQuery() != 1)
                {
                    throw new Exception("Failed to delete the language record.");
                }
            }
        }
    }
}
