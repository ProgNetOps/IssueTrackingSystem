using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class ServiceManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
