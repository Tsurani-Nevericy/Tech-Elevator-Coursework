using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class Film
    {
        /// <summary>
        /// The film's title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The film's description.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// The film's release year.
        /// </summary>
        public int ReleaseYear { get; set; }
        
        /// <summary>
        /// The film's length.
        /// </summary>
        public int Length { get; set; }

        /// <summary>
        /// The film's rating.
        /// </summary>
        public string Rating { get; set; }
    }
}
