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

            var employee = await service.GetByIdAsync(id);
            if (employee != null)
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
                string uniqueFilename = ProcessUploadedFile(model);

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


        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Employee employee = await service.GetByIdAsync(id);
            EmployeeEditViewModel employeeEditViewModel = new EmployeeEditViewModel
            {
                Id = employee.Id,
                FirstName = employee.FirstName,
                SurName = employee.SurName,
                Email = employee.Email,
                Unit = employee.Unit,
                ExistingPhotoPath = employee.PhotoPath
            };

            return View(employeeEditViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditViewModel? model)
        {
            ViewData["Title"] = "Edit Employee";


            if (ModelState.IsValid)
            {
                Employee employee = await service.GetByIdAsync(model.Id);
                employee.SurName = model.SurName;
                employee.FirstName = model.FirstName;
                employee.Email = model.Email;
                employee.Unit = model.Unit;
                if(model.Photo != null)
				{
                    //Delete old photo and replace with new
                    if (model.ExistingPhotoPath != null)
                    {
                        string filePath = Path.Combine(webHostEnvironment.WebRootPath, "images", model.ExistingPhotoPath);
                        System.IO.File.Delete(filePath);
                    }
					employee.PhotoPath = ProcessUploadedFile(model);
				}

                await service.UpdateAsync(employee);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View(model);
            }

        }

		//The parameter type is a parent class of EmployeeEditViewModel, so any of the 2 types can be safely passed as argument
		private string ProcessUploadedFile(EmployeeCreateViewModel? model)
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
