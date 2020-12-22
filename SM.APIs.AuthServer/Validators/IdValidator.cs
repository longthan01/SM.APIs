using System;
using System.ComponentModel.DataAnnotations;
using SM.APIs.AuthServer.Areas.Admin.Pages.Models;

namespace SM.APIs.AuthServer.Validators
{
    public class IdValidator : ValidationAttribute
    {
        public IdValidator()
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value != null)
            {
                var apiScope = value as ApiScopeVM;
                if(apiScope.Id <= 0)
                {
                    return new ValidationResult("Invalid Id");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid");
        }
    }
}
