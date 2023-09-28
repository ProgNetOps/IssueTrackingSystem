using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class NetworkSwitchController : Controller
    {
        private readonly INetworkSwitchService service;
        private readonly IMapper mapper;

        public NetworkSwitchController(INetworkSwitchService service,IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Switches";

            var networkSwitches = await service.GetAllAsync();
            var networkSwitchesDTO = mapper.Map<IEnumerable<NetworkSwitchDTO?>>(networkSwitches);
            return View(networkSwitchesDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Switch";

            var networkSwitch = await service.GetByIdAsync(id);
            if (networkSwitch != null)
            {
                var networkSwitchDTO = mapper.Map<NetworkSwitchDTO>(networkSwitch);
                return View(networkSwitchDTO);
            }
            else
            {
                return View(nameof(NotFound));
            }
        }

    }
}
