using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Validation.Web.Models
{
    public class RegistrationViewModel
    {
        [Display(Name = "First Name:")]
        [Required(ErrorMessage = "*")]
        [StringLength(20)]
        public string FirstName { get; set; }

        [Display(Name = "Last Name:")]
        [Required(ErrorMessage = "*")]
        [StringLength(20)]
        public string LastName { get; set; }

        [Display(Name = "Email:")]
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        public string Email { get; set; }

        [Display(Name = "Confirm Email:")]
        [EmailAddress]
        [Required(ErrorMessage = "*")]
        [Compare("Email")]
        public string EmailConfirm { get; set; }

        [Display(Name = "Password:")]
        [Required(ErrorMessage = "*")]
        [StringLength(20, MinimumLength = 8)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password:")]
        [Required(ErrorMessage = "*")]
        [Compare("Password")]
        public string PassConfirm { get; set; }

        [Display(Name = "Date of Birth:")]
        [Required(ErrorMessage = "*")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Number of Tickets:")]
        [Required(ErrorMessage = "*")]
        [Range(1, 10)]
        public int Tickets { get; set; }

    }
}