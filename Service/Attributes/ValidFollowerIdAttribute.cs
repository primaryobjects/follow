using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Service.Managers;

namespace Service.Attributes
{
    public class ValidFollowerIdAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value != null)
            {
                var followerId = (Guid)value;
                return PersonManager.Exists(followerId) ? ValidationResult.Success : new ValidationResult("Invalid Id.");
            }
            else
            {
                return new ValidationResult("Missing Id.");
            }
        }
    }
}