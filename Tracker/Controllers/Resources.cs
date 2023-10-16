using Microsoft.AspNetCore.Mvc;

namespace Tracker.Controllers
{
    public class Resources : Controller
    {

        public IActionResult TechnicalTools()
        {
            ViewData["Title"] = "Technical Tools";
            return View();
        }
        public IActionResult AdminPanel()
        {
            ViewData["Title"] = "Administrative Panel";
            return View();
        }
    }
}
