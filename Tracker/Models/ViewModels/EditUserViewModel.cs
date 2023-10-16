using System.ComponentModel.DataAnnotations;
using Tracker.CustomValidations;
using Tracker.Entity.Enums;

namespace Tracker.Models.ViewModels
{
    public class EditUserViewModel:RegisterViewModel //Inheritance is to simplify the ProcessUpload() emthod parameter type to the base class
    {
        public EditUserViewModel()
        {
            Claims = new List<string>();
            Roles = new List<string>();
        }

        public string Id { get; set; }
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
        /// Official email address of personnel
        /// </summary>
        [StringLength(70), Required(ErrorMessage = "Official email address is required")]
        [Display(Name = "Official Email")]
        [EmailAddress]
        [ValidEmailDomain("gloworld.com", ErrorMessage = "The domain name is not valid")]
        [EmailDelimiter('.', ErrorMessage = "Required email delimiter is missing")]
        public string? Email { get; set; }

        public IFormFile? Photo { get; set; }

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

        public string? ExistingPhotoPath { get; set; }

        public List<string>? Claims { get; set; }

        public IList<string>? Roles { get; set; }

    }
}
