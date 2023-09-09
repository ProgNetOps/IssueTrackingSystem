using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class BTSController : Controller
    {
        private readonly IBaseStationService service;

        public BTSController(IBaseStationService service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            var allSites = service.GetAllAsync();
            return View();
        }
    }
}
