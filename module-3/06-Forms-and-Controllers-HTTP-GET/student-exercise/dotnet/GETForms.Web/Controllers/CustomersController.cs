using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GETForms.Web.DAL;
using GETForms.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace GETForms.Web.Controllers
{
    public class CustomersController : Controller
    {
        private ICustomerDAO _db = null;

        public CustomersController(ICustomerDAO db)
        {
            _db = db;
        }


        /*/customers/index


        /customers/search?search=chris&sortBy=email*/
        public IActionResult Index()
        {
            return View(new CustomerViewModel());
        }//

        public IActionResult Search(string search="A", string sortBy="email")
        {
            IList<Customer> customers = _db.SearchForCustomers(search, sortBy);

            CustomerViewModel vm = new CustomerViewModel();
            vm.Customers = _db.SearchForCustomers(search, sortBy);

            return View("Index", vm);
        }
    }
}