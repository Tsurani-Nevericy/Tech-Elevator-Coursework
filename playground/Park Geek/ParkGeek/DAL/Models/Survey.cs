using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ParkGeek.DAL.Models
{
    public class Survey
    {
        [Required(ErrorMessage = "*")]
        public string FavoriteParkCode { get; set; }

        [Required(ErrorMessage = "*")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "*")]
        public string StateOfResidence { get; set; }

        [Required(ErrorMessage = "*")]
        public int ActivityLevel { get; set; }
    }
}
