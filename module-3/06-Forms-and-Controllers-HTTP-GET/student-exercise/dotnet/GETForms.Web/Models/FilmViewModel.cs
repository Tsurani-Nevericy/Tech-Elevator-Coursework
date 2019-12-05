using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GETForms.Web.Models
{
    public class FilmViewModel
    {
        public int MinimumLength { get; set; }
        public int MaximumLength { get; set; }
        public string Genre { get; set; }
        public IList<Film> Films { get; set; } = new List<Film>();
        public IList<SelectListItem> Genres { get; set; } = new List<SelectListItem>
        {
            new SelectListItem() { Text = "Action" },
            new SelectListItem() { Text = "Animation" },
            new SelectListItem() { Text = "Children" },
            new SelectListItem() { Text = "Classics" },
            new SelectListItem() { Text = "Comedy" },
            new SelectListItem() { Text = "Documentary" },
            new SelectListItem() { Text = "Drama" },
            new SelectListItem() { Text = "Family" },
            new SelectListItem() { Text = "Foreign" },
            new SelectListItem() { Text = "Games" },
            new SelectListItem() { Text = "Horror" },
            new SelectListItem() { Text = "Music" },
            new SelectListItem() { Text = "New"},
            new SelectListItem() { Text = "Sci-Fi" },
            new SelectListItem() { Text = "Sports" },
            new SelectListItem() { Text = "Travel" }
        };
    }
}
