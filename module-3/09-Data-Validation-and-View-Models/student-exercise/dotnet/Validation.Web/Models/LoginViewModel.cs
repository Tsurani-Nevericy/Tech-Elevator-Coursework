using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class LoginViewModel
    {
        [Display(Name = "Email:")]
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "*")]
        public string Password { get; set; }
    }
}