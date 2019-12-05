using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechElevator.Web.Models;

namespace TechElevator.Web.DAL
{
    public interface IPostDAO
    {
        IList<Post> GetPosts();
    }
}
