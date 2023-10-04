using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.ViewModels;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EmployeeController(IEmployeeService service, IWebHostEnvironment webHostEnvironment)
        {
            this.service = service;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Staff";

            var employees = await service.GetAllAsync();
            return View(employees);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Staff Details";

            var employee =await service.GetByIdAsync(id);
            if (employee!=null)
            {
                return View(employee);
            }
            else
            {
                return View(nameof(NotFound));
            }
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateViewModel? model)
        {
            ViewData["Title"] = "Create Employee";
            

            if (ModelState.IsValid)
            {
                string uniqueFilename = null;

                if (model.Photo != null)
                {
                    string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    uniqueFilename = $"{Guid.NewGuid().ToString()}_{model.Photo.FileName}";
                    string filePath = Path.Combine(uploadsFolder, uniqueFilename);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }

                Employee newEmployee = new Employee
                {
                    FirstName = model.FirstName,
                    SurName = model.SurName,
                    Unit = model.Unit,
                    Email = model.Email,
                    PhotoPath = uniqueFilename
                };

                await service.AddAsync(newEmployee);

                var allEmployee = await service.GetAllAsync();

                return RedirectToAction(nameof(Details), new { id = allEmployee.Max(q => q.Id) });
            }
            else
            {
                return View(model);
            }

        }
    }
}
