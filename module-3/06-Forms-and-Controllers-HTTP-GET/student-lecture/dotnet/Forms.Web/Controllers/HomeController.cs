using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Forms.Web.Models;
using Forms.Web.DAL;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Forms.Web.Controllers
{
    public class HomeController : Controller
    {
        private ICityDAO _dao = null;

        public HomeController(ICityDAO dao)
        {
            _dao = dao;
        }

        /// <summary>
        /// Represents an index action.
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            CityListViewModel vm = new CityListViewModel();

            var codes = _dao.GetCountryCodes();
            foreach(var code in codes)
            {
                SelectListItem item = new SelectListItem();
                item.Text = code;
                vm.CountryCodes.Add(item);
            }

            return View(vm);
        }

        public IActionResult Detail(CityListViewModel vm)
        {
            CityDetailViewModel detailViewModel = new CityDetailViewModel();

            detailViewModel.Cities = _dao.GetCities(vm.CountryCode, vm.District);
            detailViewModel.CityListVM = vm;

            var codes = _dao.GetCountryCodes();
            foreach (var code in codes)
            {
                SelectListItem item = new SelectListItem();
                item.Text = code;
                detailViewModel.CityListVM.CountryCodes.Add(item);
            }

            return View(detailViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
