using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ParkGeek;
using ParkGeek.DAL.Models;
using ParkGeekMVC.Models;
using Security.DAO;

namespace ParkGeekMVC.Controllers
{
    public class SurveyController : AuthenticationController
    {

        private IUserSecurityDAO _db1 = null;
        private IParkGeekDAO _db2 = null;

        public SurveyController(IUserSecurityDAO db1, IParkGeekDAO db2, IHttpContextAccessor httpContext) : base(db1, httpContext)
        {
            _db1 = db1;
            _db2 = db2;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Survey()
        {
            IList<Park> Parks = new List<Park>();
            Parks = _db2.GetParks();
            SurveyViewModel vm = new SurveyViewModel();
            foreach (Park p in Parks)
            {
                SelectListItem s = new SelectListItem { Text = p.ParkName, Value = p.ParkCode };
                vm.ParkList.Add(s);
            }
            return View(vm);
        }
        [HttpPost]
        public IActionResult Survey(SurveyViewModel vm)
        {
            IActionResult result = View();

            if (ModelState.IsValid)
            {
                Survey s = new Survey();                
                s.ActivityLevel = vm.ActivityLevel;
                s.Email = vm.Email;
                s.StateOfResidence = vm.StateOfResidence;
                s.FavoriteParkCode = vm.FavoriteParkCode;

                _db2.NewSurvey(s);
                result = RedirectToAction("Confirmation");
            }

            return result;
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}