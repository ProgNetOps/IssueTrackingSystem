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
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Base Stations";

            var allBaseStations = await service.GetAllAsync();
            return View(allBaseStations);
        }

    }
}
