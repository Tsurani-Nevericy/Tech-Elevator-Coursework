using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class CustomerViewModel
    {
        public string Search { get; set; }
        public string SortBy { get; set; }
        public IList<Customer> Customers { get; set; } = new List<Customer>();
        public IList<SelectListItem> Sorts { get; set; } = new List<SelectListItem> 
        { 
            new SelectListItem() { Text = "email" }, 
            new SelectListItem() { Text = "last_name" }, 
            new SelectListItem() { Text = "active"} 
        };
    }
}
