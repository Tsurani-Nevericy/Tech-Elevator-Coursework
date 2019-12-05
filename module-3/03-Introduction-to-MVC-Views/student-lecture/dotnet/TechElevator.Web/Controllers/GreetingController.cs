using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechElevator.Web.Models;

namespace TechElevator.Web.Controllers
{
    public class GreetingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hello(string message, int count)
        {
            var myMessage = new Message();
            myMessage.MyMessage = message;
            myMessage.Count = count;

            ViewData["MyMessage"] = myMessage;
            
            ViewBag.Message = myMessage;

            return View();
        }
    }
}