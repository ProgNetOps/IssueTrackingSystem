using System.ComponentModel.DataAnnotations;

namespace Tracker.Models.ViewModels
{
    public class EditRoleViewModel
    {
        public EditRoleViewModel()
        {
            Users = new List<string>();
        }

        public string? Id { get; set; }

        [Required(ErrorMessage = "Role Name is required")]
        public string? RoleName { get; set; }

        //We need to create a constructor to initialize this list
        //so as not to get argumentnullexception 
        public List<string>? Users { get; set; }
    }
}

