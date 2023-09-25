using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService service;

        public EmployeeController(IEmployeeService service)
        {
            this.service = service;
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
    }
}
