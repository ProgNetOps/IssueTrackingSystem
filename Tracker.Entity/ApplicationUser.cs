using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.CustomValidations;
using Tracker.Entity.Enums;

namespace Tracker.Entity
{
    public class ApplicationUser: IdentityUser
    {
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

        public string? PhotoPath { get; set; }

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
        [Display(Name ="Employment Status")]
        public bool IsStillEmployee { get; set; } = true;

    }
}
