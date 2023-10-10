using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.CustomValidations
{
    public class FileSizeLimitAttribute : ValidationAttribute
    {
        private readonly double maxFileSizeInMB;

        public FileSizeLimitAttribute(double maxFileSizeInMB)
        {
            this.maxFileSizeInMB = maxFileSizeInMB;
        }
        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;

            bool isFileSizeValid = false;

            if (file != null)
            {
                double fileSize  = file.Length/(1024 * 1024);
                
                    if (fileSize < maxFileSizeInMB)
                    {
                        isFileSizeValid = true;
                    }                
            }

            return isFileSizeValid;
        }
    }
}
