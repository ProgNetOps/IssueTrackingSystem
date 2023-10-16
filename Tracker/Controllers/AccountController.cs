using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.ViewModels;

namespace Tracker.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IWebHostEnvironment webHostEnvironment;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, IWebHostEnvironment webHostEnvironment)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            ViewData["Title"] = "User Registration";
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueFilename = ProcessUploadedFile(model);

                var user = new ApplicationUser 
                {
                    UserName = model.Email, 
                    Email = model.Email,
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Gender = model.Gender,
                    Unit = model.Unit,
                    PhoneNumber = model.PhoneNumber,
                    PhotoPath = uniqueFilename
                };

                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    //If an admin creates a new user profile
                    if (signInManager.IsSignedIn(User) && (User.IsInRole("Admin") || User.IsInRole("Super Admin")))
                    {
                        return RedirectToAction("ListUsers", "Administration");
                    }
                    //If new user registers to create profile by self
                    else
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        return RedirectToAction(nameof(Index), "Home");
                    }
                    
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
            else
            {
                return View(model);
            }
        }


        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            ViewData["Title"] = "Login";
            return View();
        }

        /// <summary>
        /// Login action for straightforward login as well as if there is a return url, i.e user has earlier tried to access unauthorized resource before being returned to the login page
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        //make returnurl type nullable to prevent a "returnUrl is required" error
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    //WATCH FOR OPEN REDIRECT VULNERABILITY If there is a return url parameter
                    if ((string.IsNullOrEmpty(returnUrl) == false) && (Url.IsLocalUrl(returnUrl) == true))
                    {
                        return Redirect(returnUrl);
                    }
                    else //If there is no return url parameter
                    {
                        return RedirectToAction(nameof(Index), "Home");

                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid Login Attempt!");
                    return View(model);
                }
            }
            else
            {
                return View(model);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        /// <summary>
        /// This server-side method is used for remote validation of email field during registration of new user
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> IsEmailInUse(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return Json(true);
            }
            else
            {
                return Json($"{email} is already in use");
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

        [HttpGet]
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }


    }
}
