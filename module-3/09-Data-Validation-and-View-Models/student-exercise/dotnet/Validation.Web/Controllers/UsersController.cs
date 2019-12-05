using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SessionControllerData;
using Validation.Web.Models;


namespace Validation.Web.Controllers
{
    public class UsersController : SessionController
    {
        public UsersController(IHttpContextAccessor httpContext) : base(httpContext)
        {
            //DON'T READ THIS TEXT IT CAUSES IMMEDIATE RETINAL CANCER!
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegistrationViewModel vm)
        {
            IActionResult result = View();

            if (ModelState.IsValid)
            {
                SetTempData("message", "registered");
                result = RedirectToAction("Confirmation");
            }

            return result;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel vm)
        {
            IActionResult result = View();

            if (ModelState.IsValid)
            {            
                SetTempData("message", "logged in");
                result = RedirectToAction("Confirmation");
            }

            return result;
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            string message = GetTempData<string>("message");
            return View("Confirmation", (object)message);
        }

    }
}