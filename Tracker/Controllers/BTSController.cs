using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class BTSController : Controller
    {
        private readonly IBaseStationService service;
        private readonly IMapper mapper;

        public BTSController(IBaseStationService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Base Stations";

            var BaseStations = await service.GetAllAsync();
            var BaseStationsDTO = mapper.Map<IEnumerable<BTSDTO>>(BaseStations);
            return View(BaseStationsDTO);
        }

    }
}
