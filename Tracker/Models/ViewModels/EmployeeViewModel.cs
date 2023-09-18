using System.ComponentModel.DataAnnotations;

namespace Tracker.Models.ViewModels
{
    public class EmployeeViewModel
    {
        #region Properties        
        
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Surname is required")]
        [StringLength(25, ErrorMessage = "Maximum character count of 25 is exceeded")]
        [Display(Name = "First Name")]
        public string? FirstName { get; set; }


        /// <summary>
        /// Official phone number of Glo staff
        /// </summary>
        /// <summary>
        [Required(ErrorMessage = "Official number is required")]
        [RegularExpression(@"^(0805557)[0-9]{4}$", ErrorMessage = "Invalid staff number")]
        [Display(Name = "Phone")]
        public string? StaffPhone { get; set; }


        /// <summary>
        /// Staff ID of Glo staff
        /// </summary>
        [Required(ErrorMessage = "staff id is required")]
        public int StaffId { get; set; }


        /// <summary>
        /// Official email address of Glo staff
        /// </summary>
        [StringLength(70), Required(ErrorMessage = "Official email address is required")]
        [Display(Name = "Official Email")]
        [RegularExpression(@"^[A-Za-z]+[.]{1}[A-Za-z]+(@gloworld.com)$", ErrorMessage = "Invalid email address")]
        [EmailAddress]
        public string? Email { get; set; }


        /// <summary>
        /// Department
        /// </summary>
        public string? Department { get; set; }

        public IFormFile? Photo { get; set; }

        /// <summary>
        /// Shows staff is still in company's employ
        /// </summary>
        public bool IsStillEmployee { get; set; } = true;

        #endregion
    }
}
