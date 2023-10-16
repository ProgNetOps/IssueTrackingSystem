using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracker.CustomValidations
{
    /// <summary>
    /// A custom class for restricting alowed file types through their file extensions
    /// </summary>
    public class PermittedFileExtensionsAttribute : ValidationAttribute
    {
        private readonly string[]? allowedFileExtensions;
        /// <summary>
        /// The constructor that takes an array of file extensions as parameter
        /// </summary>
        /// <param name="fileExtension">
        /// The permitted file extensions, separated by commas
        /// </param>
        public PermittedFileExtensionsAttribute(params string[]? allowedFileExtensions)
        {
            this.allowedFileExtensions = allowedFileExtensions;
        }

        public override bool IsValid(object? value)
        {
            var file = value as IFormFile;

            bool isFileTypeValid = false;

            if (file != null)
            {

                string? extension = Path.GetExtension(file.FileName);

                for (int i = 0; i < allowedFileExtensions.Length; i++)
                {
                    if (extension.Equals(allowedFileExtensions[i], StringComparison.OrdinalIgnoreCase))
                    {
                        isFileTypeValid = true;
                        break;
                    }
                }
            }
            return isFileTypeValid;
        }
    }
}
