using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;

        public ClientController(IClientService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Clients";
            var allClients = await service.GetAllAsync();
            return View(allClients);
        }
    }
}
