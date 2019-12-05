using Post.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.DAL
{
    public class ReviewSqlDAO : IReviewDAO
    {
        private readonly string connectionString;
        private const string _getLastIdSQL = "SELECT CAST(SCOPE_IDENTITY() as int);";

        public ReviewSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Returns a list of all reviews
        /// </summary>
        /// <returns></returns>
        public IList<Review> GetAllReviews()
        {
            List<Review> result = new List<Review>();

            // Create a SQL string
            const string sql = "select * from reviews;";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql, conn);

                // Execute command object
                SqlDataReader reader = cmd.ExecuteReader();

                // If it was a Select then parse the result set into objects
                while (reader.Read())
                {
                    // Create a new object
                    Review newReview = new Review();
                    newReview.ReviewId = Convert.ToInt32(reader["review_id"]);
                    newReview.Username = Convert.ToString(reader["username"]);
                    newReview.Rating = Convert.ToInt32(reader["rating"]);
                    newReview.ReviewTitle = Convert.ToString(reader["review_title"]);
                    newReview.ReviewText = Convert.ToString(reader["review_text"]);
                    newReview.ReviewDate = Convert.ToDateTime(reader["review_date"]);

                    // Add object to List if more than one row retured
                    result.Add(newReview);
                }
            }
            // Return new objects
            return result;
        }

        /// <summary>
        /// Saves a new review to the system.
        /// </summary>
        /// <param name="newReview"></param>
        /// <returns></returns>
        public int SaveReview(Review newReview)
        {
            int result = 0;

            // Create a SQL string
            const string sql = "insert into reviews (username, rating, review_title, review_text, review_date) " +
                                "values (@username, @rating, @review_title, @review_text, getdate());";

            // Create a connection object
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection
                conn.Open();

                // Create a command object
                SqlCommand cmd = new SqlCommand(sql + _getLastIdSQL, conn);

                // Insert parameters in command object
                cmd.Parameters.AddWithValue("@username", newReview.Username);
                cmd.Parameters.AddWithValue("@rating", newReview.Rating);
                cmd.Parameters.AddWithValue("@review_title", newReview.ReviewTitle);
                cmd.Parameters.AddWithValue("@review_text", newReview.ReviewText);

                // Execute command object
                result = (int)cmd.ExecuteScalar();
            }
            return result;
        }
    }
}
