using Microsoft.AspNetCore.Mvc.Rendering;
using ParkGeek.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkGeekMVC.Models
{
    public class ParkViewModel
    {
        public IList<Park> ParkList = new List<Park>();
    }
}
