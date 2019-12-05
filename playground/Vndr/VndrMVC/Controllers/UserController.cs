using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VendingService;
using VendingService.Exceptions;
using VendingService.Interfaces;
using VendingService.Models;

namespace VndrMVC.Controllers
{
    public class UserController : BaseController
    {
        public UserController(IVendingService db, IVendingMachine vm, IHttpContextAccessor httpContext) : base(db, vm, httpContext)
        {
        }

        [HttpGet]
        public ActionResult Login()
        {
            if (IsAuthenticated)
            {
                LogoutUser();
            }

            return View("Login");
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            ActionResult result = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                LoginUser(model.Username, model.Password);

                // Store user on the session
                SetSessionData(UserKey, CurrentUser);

                result = RedirectToAction("Index", "Vending");
            }
            catch (Exception)
            {
                result = View("Login");
            }

            return result;
        }

        [HttpGet]
        public ActionResult Register()
        {
            if (IsAuthenticated)
            {
                LogoutUser();
            }

            return View("Register");
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            ActionResult result = null;

            try
            {
                if (!ModelState.IsValid)
                {
                    throw new Exception();
                }

                try
                {
                    User userModel = new User();
                    userModel.ConfirmPassword = model.ConfirmPassword;
                    userModel.Password = model.Password;
                    userModel.FirstName = model.FirstName;
                    userModel.LastName = model.LastName;
                    userModel.Username = model.Username;
                    userModel.Email = model.Email;
                    RegisterUser(userModel);
                }
                catch (UserExistsException)
                {
                    ModelState.AddModelError("invalid-user", "The username is already taken.");
                    throw;
                }

                result = RedirectToAction("Index", "Vending");
            }
            catch (Exception)
            {
                result = View("Register");
            }

            return result;
        }
    }
}
