using System.ComponentModel.DataAnnotations;
using Tracker.CustomValidations;
using Tracker.Entity.Enums;

namespace Tracker.Models.ViewModels
{
    public class EmployeeCreateViewModel
    {
        /// <summary>
        /// Surname of Glo staff
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        [StringLength(25, ErrorMessage = "Maximum character count of 25 is exceeded")]
        [Display(Name = "Surname")]
        public string? SurName { get; set; }

        /// <summary>
        /// First Name of Glo staff
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
        /// Official email address of Glo staff
        /// </summary>
        [StringLength(70), Required(ErrorMessage = "Official email address is required")]
        [Display(Name = "Official Email")]
        [RegularExpression(@"^[A-Za-z]+[.]{1}[A-Za-z]+(@gloworld.com)$", ErrorMessage = "Invalid email address")]
        [EmailAddress]
        public string? Email { get; set; }
        [Display(Name ="Profile Picture")]
        //[PermittedFileExtensions(".jpg",".jpeg",".png",ErrorMessage ="Uploaded file format is not supported")]
        //[FileSizeLimit(2, ErrorMessage ="Maximum file size is 2MB")] //2MB picture
        public IFormFile? Photo { get; set; }
    }
}
