using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.DAL
{
    public class PostSqlDAO : IPostDAO
    {
        private string connectionString;

        /// <summary>
        /// Creates a new dao.
        /// </summary>
        /// <param name="connectionString"></param>
        public PostSqlDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        /// <summary>
        /// Gets all posts from sql database.
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM posts", conn);
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        posts.Add(CreatePostFromReader(reader));
                    }
                }
            }
            catch (SqlException ex)
            {
                // Log the exception
                throw;
            }

            return posts;
        }

        /// <summary>
        /// Creates a post object from a reader row.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        private Post CreatePostFromReader(SqlDataReader reader)
        {
            Post post = new Post()
            {
                Username = Convert.ToString(reader["username"]),
                UserImage = Convert.ToString(reader["userImage"]),
                PostImage = Convert.ToString(reader["postImage"]),
                Likes = Convert.ToInt32(reader["likes"]),
                HasBeenLiked = Convert.ToBoolean(reader["hasBeenLiked"]),
                Caption = Convert.ToString(reader["caption"])
            };

            return post;
        }
    }
}
