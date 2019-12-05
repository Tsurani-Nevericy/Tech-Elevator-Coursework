using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendingService;

namespace VndrMVC.ViewComponents
{
    [ViewComponent(Name = "NavBar")]
    public class NavBarViewComponent : ViewComponent
    {
        private readonly IVendingMachine _vm;

        public NavBarViewComponent(IVendingMachine vm)
        {
            _vm = vm;
        }

        public IViewComponentResult Invoke()
        {
            return View(_vm);
        }
    }
}