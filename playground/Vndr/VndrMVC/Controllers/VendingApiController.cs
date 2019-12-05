using System;
using VendingService.Models;
using VendingService;
using Microsoft.AspNetCore.Mvc;
using VendingService.Interfaces;
using Microsoft.AspNetCore.Http;

namespace VndrMVC.Controllers
{
    public class VendingApiController : BaseController
    {
        
        public VendingApiController(IVendingService db, IVendingMachine vm, IHttpContextAccessor httpContext) : base(db, vm, httpContext)
        {
        }

        [HttpGet]
        [Route("api/inventory")]
        public ActionResult GetVendingItems()
        {
            var jsonResult = Json(_vm.VendingItems);
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsCustomer || _vm.Role.IsServiceman || _vm.Role.IsExecutive);
        }

        [HttpGet]
        [Route("api/balance")]
        public ActionResult GetVendingBalance()
        {
            var jsonResult = Json(_vm.RunningTotal);
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsCustomer || _vm.Role.IsServiceman || _vm.Role.IsExecutive);
        }

        [HttpPost]
        [Route("api/feedmoney")]
        public ActionResult FeedMoney(double amount)
        {
            StatusViewModel result = null;
            try
            {
                _vm.FeedMoney(amount);
                result = new StatusViewModel(eStatus.Success);
            }
            catch (Exception ex)
            {
                result = new StatusViewModel(eStatus.Error, ex.Message);
            }

            var jsonResult = Json(result);
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsCustomer || _vm.Role.IsServiceman || _vm.Role.IsExecutive);
        }

        [HttpPost]
        [Route("api/purchase")]
        public ActionResult Purchase(int row, int col)
        {
            StatusViewModel result = null;
            try
            {
                var item = _vm.PurchaseItem(row, col);
                result = new StatusViewModel(eStatus.Success, item.Category.Noise);
            }
            catch (Exception ex)
            {
                result = new StatusViewModel(eStatus.Error, ex.Message);
            }

            var jsonResult = Json(result);
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsCustomer || _vm.Role.IsServiceman || _vm.Role.IsExecutive);
        }

        [HttpPost]
        [Route("api/change")]
        public ActionResult MakeChange()
        {
            Change change = null;
            StatusViewModel status = null;
            try
            {
                change = _vm.ReturnChange();
                status = new StatusViewModel(eStatus.Success);
            }
            catch (Exception ex)
            {
                status = new StatusViewModel(eStatus.Error, ex.Message);
            }

            var jsonResult = Json(new ChangeViewModel(change, status));
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsCustomer || _vm.Role.IsServiceman || _vm.Role.IsExecutive);
        }

        [HttpGet]
        [Route("api/report")]
        public ActionResult GetReport(int? year, int? userId)
        {
            var jsonResult = Json(_vm.GetReport(year, userId));
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsExecutive);
        }

        [HttpGet]
        [Route("api/log")]
        public ActionResult GetLog(DateTime? startDate, DateTime? endDate)
        {
            JsonResult jsonResult = null;
            try
            {
                jsonResult = Json(_vm.GetLog(startDate, endDate));
            }
            catch (Exception ex)
            {
                var status = new StatusViewModel(eStatus.Error, ex.Message);
                jsonResult = Json(status);
            }
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsExecutive);
        }

        [HttpGet]
        [Route("api/users")]
        public ActionResult GetUsers()
        {
            var jsonResult = Json(_vm.Users);
            return GetAuthenticatedJson(jsonResult, _vm.Role.IsAdministrator);
        }
    }
}