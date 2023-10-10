using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.CustomValidations
{
    public class ValidEmailDomainAttribute : ValidationAttribute
    {
        public readonly string allowedDomain;

        public ValidEmailDomainAttribute(string allowedDomain)
        {
            this.allowedDomain = allowedDomain;
        }

        public override bool IsValid(object? value)
        {
            value = value as string;
            string[]? emailParts = value?.ToString()?.Split('@');
            if (string.IsNullOrEmpty(value as string) == false && emailParts[1].ToUpper() == allowedDomain.ToUpper())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}


