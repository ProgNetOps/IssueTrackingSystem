using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.CustomValidations
{
    public class EmailDelimiterAttribute : ValidationAttribute
    {
        public readonly char allowedDelimiter;

        public EmailDelimiterAttribute(char allowedDelimiter)
        {
            this.allowedDelimiter = allowedDelimiter;
        }

        public override bool IsValid(object? value)
        {
            value = value as string;
            string[]? emailParts = value?.ToString()?.Split('@');
            if (string.IsNullOrEmpty(value as string) == false && emailParts[0].Contains(allowedDelimiter))
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
