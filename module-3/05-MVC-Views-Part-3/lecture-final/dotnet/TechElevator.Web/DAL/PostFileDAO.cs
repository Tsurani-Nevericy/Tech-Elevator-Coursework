using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.DAL
{
    public class PostFileDAO : IPostDAO
    {
        private string filePath;

        /// <summary>
        /// Creates a new file-based dao.
        /// </summary>
        /// <param name="filePath"></param>
        public PostFileDAO(string filePath)
        {
            this.filePath = filePath;
        }

        /// <summary>
        /// Gets all posts from a file.
        /// </summary>
        /// <returns></returns>
        public IList<Post> GetPosts()
        {
            List<Post> posts = new List<Post>();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        Post post = GetPostFromLine(line);
                        posts.Add(post);
                    }
                }
            }
            catch (IOException ex)
            {
                // Log the exception
                throw;
            }

            return posts;
        }

        /// <summary>
        /// Creates a post from a pipe-delimited string.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private Post GetPostFromLine(string line)
        {
            string[] fields = line.Split('|');

            Post post = new Post()
            {
                Username = fields[0],
                UserImage = fields[1],
                PostImage = fields[2],
                Likes = int.Parse(fields[3]),
                HasBeenLiked = bool.Parse(fields[4]),
                Caption = fields[5]
            };

            return post;
        }
    }
}
