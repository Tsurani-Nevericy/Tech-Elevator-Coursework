using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IntroToRazor.Web.Models;

namespace IntroToRazor.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        // Sample URLs
        // home/fizzbuzz (defaults to 100)
        // home/fizzbuzz?number=50 (sets number to 50)
        public IActionResult FizzBuzz(int number = 100)
        {
            ViewData["number"] = number;

            return View();
        }

        // home/fibonacci (defaults to 20)
        // home/fibonacci?max=30 (sets max to 30)
        public IActionResult Fibonacci(int max = 20)
        {
            ViewData["max"] = max;

            return View();
        }

        // home/echo?word=hello world&count=20
        // home/echo
        public IActionResult Echo(string word = "pick a word", int count = 10)
        {
            ViewData["word"] = word;
            ViewData["count"] = count;

            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
