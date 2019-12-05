using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Post.Web.DAL;
using Post.Web.Models;

namespace Post.Web.Controllers
{
    public class HomeController : Controller
    {
        IReviewDAO _db = null;
        public HomeController(IReviewDAO db)
        {
            _db = db;
        }
        // GET: Home
        public IActionResult Index()
        {
            ReviewViewModel vm = new ReviewViewModel();
            vm.Reviews = _db.GetAllReviews();
            return View(vm);
        }
        [HttpGet]
        public IActionResult NewReview()
        {
            return View("NewReview");
        }

        [HttpPost]
        public IActionResult NewReview(Review review)
        {
            IActionResult result = null;

            try
            {
                _db.SaveReview(review);
                result = RedirectToAction("Index", new { Name = review.ReviewTitle });
            }
            catch (Exception)
            {
                result = RedirectToAction("Results", new { Name = review.ReviewTitle, Error = "Failed" });
            }

            return result;
        }
        [HttpGet]
        public IActionResult Results(SuccessViewModel vm)
        {
            return View("Success", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
