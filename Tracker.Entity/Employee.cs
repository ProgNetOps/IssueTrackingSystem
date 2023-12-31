﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tracker.CustomValidations;
using Tracker.Entity.Contract;
using Tracker.Entity.Enums;

namespace Tracker.Entity
{
    /// <summary>
    /// Class that represents employees
    /// </summary>
    public class Employee : IEntityBase
    {
        #region Properties        
        [Key]
        public int Id { get; set; }


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
        [Required(ErrorMessage ="Department/Unit is required")]
        public Unit? Unit { get; set; }

        /// <summary>
        /// Official email address of Glo staff
        /// </summary>
        [StringLength(70), Required(ErrorMessage = "Official email address is required")]
        [Display(Name = "Official Email")]
        [EmailAddress]
        [ValidEmailDomain("gloworld.com", ErrorMessage = "The domain name is not valid")]
        [EmailDelimiter('.', ErrorMessage = "Required email delimiter is missing")]
        public string? Email { get; set; }

        public string? PhotoPath { get; set; }

        ///// <summary>
        ///// Official phone number of Glo staff
        ///// </summary>
        ///// <summary>
        //[Required(ErrorMessage = "Official number is required")]
        //[RegularExpression(@"^(0805557)[0-9]{4}$", ErrorMessage = "Invalid staff number")]
        //[Display(Name = "Phone")]
        //public string? StaffPhone { get; set; }

        ///// <summary>
        ///// Staff ID of Glo staff
        ///// </summary>
        //[Required(ErrorMessage = "staff id is required")]
        //public int StaffId { get; set; }

        ///// <summary>
        ///// State of residence
        ///// </summary>
        //public int StateId { get; set; }
        //[ForeignKey(nameof(StateId))]
        //public State State { get; set; }

        //public string? Gender { get; set; }


        ///// <summary>
        ///// Shows staff is still in company's employ
        ///// </summary>
        //public bool IsStillEmployee { get; set; } = true;

        #endregion
    }
}
