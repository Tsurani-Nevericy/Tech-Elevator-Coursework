using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Forms.Web.Models
{
    public class CountryCodeAttribute : ValidationAttribute, IClientModelValidator
    {
        private string _countryCode;

        public CountryCodeAttribute()
        {

        }

        public CountryCodeAttribute(string countryCode)
        {
            _countryCode = countryCode;
        }

        public void AddValidation(ClientModelValidationContext context)
        {
            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ValidationResult result = ValidationResult.Success;

            // We can only use this attribute on Movies so cast to a Movie first.
            string countryCode = (string)value;

            // Once casted, the object can now be checked for the rules.
            if (countryCode.Length != 3)
            {
                result = new ValidationResult($"The country code must be 3 and only 3 characters.");
            }

            return result;
        }
    }
}
