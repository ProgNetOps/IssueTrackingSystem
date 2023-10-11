namespace Tracker.Models.ViewModels
{
    public class UserRoleViewModel
    {
        public string? UserId { get; set; } //Id property is string from IdentityUser, but int from Employee
        public string? UserName { get; set; }
        public bool IsSelected { get; set; }
    }
}
