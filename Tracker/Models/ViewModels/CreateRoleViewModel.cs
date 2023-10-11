using System.ComponentModel.DataAnnotations;

namespace Tracker.Models.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        [Display(Name ="Role Name")]
        public string RoleName { get; set; }
    }
}
