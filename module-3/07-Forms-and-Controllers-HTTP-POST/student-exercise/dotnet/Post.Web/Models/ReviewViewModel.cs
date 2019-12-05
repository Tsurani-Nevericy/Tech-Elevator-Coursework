using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Post.Web.Models
{
    public class ReviewViewModel
    {
        public IList<Review> Reviews { get; set; } = new List<Review>();
    }
}
