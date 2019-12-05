using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechElevator.Web.Models
{
    public class Post
    {
        /// <summary>
        /// The post's user.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// The user's image.
        /// </summary>
        public string UserImage { get; set; }

        /// <summary>
        /// The image for the post.
        /// </summary>
        public string PostImage { get; set; }

        /// <summary>
        /// Number of likes received.
        /// </summary>
        public int Likes { get; set; }

        /// <summary>
        /// If you have liked the post.
        /// </summary>
        public bool HasBeenLiked { get; set; }

        /// <summary>
        /// Caption for the post.
        /// </summary>
        public string Caption { get; set; }        
    }
}
