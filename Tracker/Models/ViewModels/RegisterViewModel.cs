using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tracker.CustomValidations;
using Tracker.Entity.Enums;
using Tracker.Entity;

namespace Tracker.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [ValidEmailDomain("gloworld.com", ErrorMessage = "The domain name is not valid")]
        [EmailDelimiter('.', ErrorMessage = "Required email delimiter is missing")]
        [Remote(action: "IsEmailInUse", controller:"Account")]//For remote email validation
        public string? Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare(nameof(Password),ErrorMessage ="Password and confirmation do not match")]
        [Display(Name ="Confirm Password")]
        public string ConfirmPassword { get; set; }

        public Gender? Gender { get; set; }

        /// <summary>
        /// Surname of personnel
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        [StringLength(25, ErrorMessage = "Maximum character count of 25 is exceeded")]
        [Display(Name = "Surname")]
        public string? SurName { get; set; }

        /// <summary>
        /// First Name of personnel
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required")]
        [StringLength(25, ErrorMessage = "Maximum character count of 25 is exceeded")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }

        /// <summary>
        /// Department/Unit
        /// </summary>
        [Display(Name = "Department/Unit")]
        [Required(ErrorMessage = "Department/Unit is required")]
        public Unit? Unit { get; set; }

        /// <summary>
        /// Official phone number of Glo staff
        /// </summary>
        /// <summary>
        [Required(ErrorMessage = "Official number is required")]
        [RegularExpression(@"^(0805557)[0-9]{4}$", ErrorMessage = "Invalid staff number")]
        [Display(Name = "Phone")]
        public string? PhoneNumber { get; set; }


        /// <summary>
        /// Shows staff is still in company's employ
        /// </summary>
        [Display(Name = "Employment Status")]
        public bool IsStillEmployee { get; set; } = true;

        [Display(Name = "Profile Picture")]
        //[PermittedFileExtensions(".jpg",".jpeg",".png",ErrorMessage ="Uploaded file format is not supported")]
        //[FileSizeLimit(2, ErrorMessage ="Maximum file size is 2MB")] //2MB picture
        public IFormFile? Photo { get; set; }
    }
}
