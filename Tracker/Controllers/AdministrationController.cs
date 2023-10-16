using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.ViewModels;

namespace Tracker.Controllers
{
    //[Authorize(Roles = "User,Super Admin")]
    public class AdministrationController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AdministrationController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public IActionResult CreateRole()
        {
            ViewData["Title"] = "Create New Role";
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> CreateRole(CreateRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityRole identityRole = new IdentityRole
                {
                    Name = model.RoleName,
                };

                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(ListRoles));//Controller not listed since it's same
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }

        }



        [HttpGet]
        public IActionResult ListRoles()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }



        [HttpGet]
        public async Task<IActionResult> EditRole(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null)
            {
                ViewData["ErrorMessage"] = $"Role with Id = {id} cannot be found.";
                return View("NotFound");
            }
            else
            {
                EditRoleViewModel? model = new EditRoleViewModel
                {
                    Id = role.Id,
                    RoleName = role.Name
                };

                foreach (var user in userManager.Users)
                {
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        model?.Users?.Add(user.UserName);
                    }
                }
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditRole(EditRoleViewModel? model)
        {
            var role = await roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ViewData["ErrorMessage"] = $"Role with Id = {model?.Id} cannot be found.";
                return View("NotFound");
            }
            else
            {
                role.Name = model?.RoleName;
                var result = await roleManager.UpdateAsync(role);

                if (result.Succeeded)
                {
                    return RedirectToAction("Listroles");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return View(model);
            }
        }


        [HttpGet]
        public async Task<IActionResult> EditUsersInRole(string roleId)
        {
            ViewBag.roleId = roleId;
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            else
            {
                var model = new List<UserRoleViewModel>();

                foreach (var user in userManager.Users)
                {
                    UserRoleViewModel userRoleViewModel = new UserRoleViewModel
                    {
                        UserName = user.UserName,
                        UserId = (user as IdentityUser).Id //***Later addition***
                    };
                    if (await userManager.IsInRoleAsync(user, role.Name))
                    {
                        userRoleViewModel.IsSelected = true;
                    }
                    else
                    {
                        userRoleViewModel.IsSelected = false;
                    }
                    model.Add(userRoleViewModel);
                }
                return View(model);
            }
        }


        [HttpPost]
        public async Task<IActionResult> EditUsersInRole(List<UserRoleViewModel> model, string roleId)
        {
            var role = await roleManager.FindByIdAsync(roleId);
            if (role == null)
            {
                ViewBag.ErrorMessage = $"Role with Id = {roleId} cannot be found";
                return View("NotFound");
            }
            else
            {
                for (int i = 0; i < model.Count; i++)
                {
                    var user = await userManager.FindByIdAsync(model[i].UserId);//****PROBLEM****
                    IdentityResult? result = null;
                    if (model[i].IsSelected && !(await userManager.IsInRoleAsync(user, role.Name)))
                    {
                        result = await userManager.AddToRoleAsync(user, role.Name);
                    }
                    else if (!model[i].IsSelected && await userManager.IsInRoleAsync(user, role.Name))
                    {
                        result = await userManager.RemoveFromRoleAsync(user, role.Name);
                    }
                    else
                    {
                        continue;
                    }

                    if (result.Succeeded)
                    {
                        if (i < model.Count - 1)
                        {
                            continue;
                        }
                        else
                        {
                            return RedirectToAction("EditRole", new { Id = roleId });
                        }
                    }
                }
                return RedirectToAction("EditRole", new { Id = roleId });
            }
        }

        
        [HttpGet]
        public IActionResult ListUsers()
        {
            ViewData["Title"] = "All Users";

            var users = userManager.Users;//returns a list of all users
            return View(users);
        }



        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ViewData["Title"] = "Edit User";

            var user = await userManager.FindByIdAsync(id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                var userClaims = await userManager.GetClaimsAsync(user);
                var userRoles = await userManager.GetRolesAsync(user);

                var model = new EditUserViewModel
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    SurName = user.SurName,
                    PhoneNumber = user.PhoneNumber,
                    Unit = user.Unit,
                    ExistingPhotoPath = user.PhotoPath,
                    Email = user.Email,
                    Gender = user.Gender,
                    IsStillEmployee = user.IsStillEmployee,
                    Claims = userClaims.Select(c => c.Value).ToList(),
                    Roles = userRoles
                };

                return View(model);
            }

        }


        [HttpPost]
        public async Task<IActionResult> EditUser(EditUserViewModel model)
        {
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                ViewBag.ErrorMessage = $"User with id = {model.Id} cannot be found";
                return View("NotFound");
            }
            else
            {
                user.Id = model.Id;
                user.UserName = model.Email;
                user.FirstName = model.FirstName;
                user.SurName = model.SurName;
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.IsStillEmployee = model.IsStillEmployee;
                user.Unit = model.Unit;
                user.Gender = model.Gender;
                user.PhotoPath = ProcessUploadedFile(model);

                var result = await userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return RedirectToAction("ListUsers");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
        }

        private string ProcessUploadedFile(RegisterViewModel? model)
        {
            string uniqueFilename = null;

            if (model.Photo != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFilename = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Photo.CopyTo(fileStream);
                }
            }

            return uniqueFilename;
        }

    }
}
