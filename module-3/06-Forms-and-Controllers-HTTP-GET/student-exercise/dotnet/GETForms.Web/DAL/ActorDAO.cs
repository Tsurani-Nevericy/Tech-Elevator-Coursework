using GETForms.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.DAL
{
    public class ActorDAO : IActorDAO
    {
        private string connectionString;

        public ActorDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of actors by last name search.
        /// </summary>
        /// <param name="lastNameSearch"></param>
        /// <returns></returns>
        public IList<Actor> FindActors(string lastNameSearch)
        {
            IList<Actor> actors = new List<Actor>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT first_name, last_name FROM actor WHERE last_name LIKE @last_name ORDER BY last_name", conn);
                cmd.Parameters.AddWithValue("@last_name", "%" + lastNameSearch + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    actors.Add(MapRowToActor(reader));
                }
            }

            return actors;
        }

        /// <summary>
        /// Maps a sql data row to an actor object.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Actor MapRowToActor(SqlDataReader reader)
        {
            return new Actor()
            {
                FirstName = Convert.ToString(reader["first_name"]),
                LastName = Convert.ToString(reader["last_name"])
            };
        }
    }

}
