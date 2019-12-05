using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.DAL;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class HomeController : Controller
    {
        IPostDAO _db = null;

        public HomeController(IPostDAO db)
        {
            _db = db;
            //_db = new PostSqlDAO("Data Source=.\\sqlexpress;Initial Catalog=TEgram;Integrated Security=True");
            //_db = new PostFileDAO(@".\bin\Debug\netcoreapp2.1\DAL\data.csv");
        }

        public IActionResult Index()
        {
            
            IList<Post> posts = _db.GetPosts();

            return View(posts);
        }

        public IActionResult Tile()
        {
            IList<Post> posts = _db.GetPosts();

            return View();
        }

        public IActionResult Table()
        {
            IList<Post> posts = _db.GetPosts();

            return View();
        }

    }
}