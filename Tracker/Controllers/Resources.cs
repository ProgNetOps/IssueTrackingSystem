using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class Resources : Controller
    {

        public IActionResult Facilities()
        {
            ViewData["Title"] = "Technical Tools";
            return View();
        }
        public IActionResult AdminPanel()
        {
            ViewData["Title"] = "Administrative Panel";
            return View();
        }
        public IActionResult ServiceManagementPanel()
        {
            ViewData["Title"] = "ServiceManagement Panel";
            return View();
        }
    }
}
