using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using VendingService;
using VendingService.Interfaces;

namespace VndrMVC.Controllers
{
    public class VendingController : BaseController
    {
        public VendingController(IVendingService db, IVendingMachine vm, IHttpContextAccessor httpContext) : base(db, vm, httpContext)
        {
            
        }
        
        [HttpGet]
        public ActionResult Index()
        {
            string nextView = "Index";

            if (_vm.Role.IsAdministrator)
            {
                nextView = "Admin";
            }

            return GetAuthenticatedView(nextView);
        }
                
        [HttpGet]
        public ActionResult Log()
        {
            if (!_vm.Role.IsExecutive)
            {
                _vm.LogoutUser();
            }

            LogViewModel lvm = new LogViewModel();
            lvm.Users = _vm.Users;
            lvm.Products = _vm.Products;
            lvm.OperationTypes = _vm.OperationTypes;

            return GetAuthenticatedView("Log", lvm);
        }

        [HttpGet]
        public ActionResult Report()
        {
            if (!_vm.Role.IsExecutive)
            {
                _vm.LogoutUser();
            }

            return GetAuthenticatedView("Report", _vm.Users);
        }

        [HttpGet]
        public ActionResult About()
        {
            return GetAuthenticatedView("About");
        }

        [HttpGet]
        public ActionResult Restock()
        {
            if (!_vm.Role.IsServiceman)
            {
                _vm.LogoutUser();
            }

            return GetAuthenticatedView("Restock");
        }

        [HttpPost]
        public ActionResult Restock(RestockViewModel rvm)
        {
            if (!_vm.Role.IsServiceman)
            {
                _vm.LogoutUser();
            }

            _vm.Restock(rvm.Qty);

            return GetAuthenticatedView("Index");
        }

        [HttpGet]
        public ActionResult Admin()
        {
            if (!_vm.Role.IsAdministrator)
            {
                _vm.LogoutUser();
            }

            return GetAuthenticatedView("Admin");
        }
    }
}