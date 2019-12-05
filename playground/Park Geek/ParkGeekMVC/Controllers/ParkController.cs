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
    public class ParkController : AuthenticationController
    {

        private IUserSecurityDAO _db1 = null;
        private IParkGeekDAO _db2 = null;

        public ParkController(IUserSecurityDAO db1, IParkGeekDAO db2, IHttpContextAccessor httpContext) : base(db1, httpContext)
        {
            _db1 = db1;
            _db2 = db2;
        }

        public IActionResult Index()
        {
            ParkViewModel vm = new ParkViewModel();
            vm.ParkList = _db2.GetParks();
            return View(vm);
        }

        public IActionResult Favorites()
        {
            IList<FavoritesViewModel> vmList = new List<FavoritesViewModel>();
            IList<SurveyData> favoriteParks = new List<SurveyData>();
            favoriteParks = _db2.GetSurveyParks();
            foreach (SurveyData sd in favoriteParks)
            {
                Park newPark = _db2.GetPark(sd.ParkCode);
                FavoritesViewModel vm = new FavoritesViewModel();
                vm.NumVotes = sd.NumVotes;
                vm.ParkCode = sd.ParkCode;
                vm.ParkName = newPark.ParkName;
                vm.ParkDescription = newPark.ParkDescription;
                vmList.Add(vm);
            }
            return View(vmList);
        }

        public IActionResult Detail()
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
