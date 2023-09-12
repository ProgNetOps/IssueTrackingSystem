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

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "BTS";

            var BaseStation = await service.GetByIdAsync(id);
            var BaseStationDTO = mapper.Map<BTSDTO>(BaseStation);

            return View(BaseStationDTO);
        }

        public async Task<IActionResult> Create(BTSDTO model)
        {
            ViewData["Title"] = "New BTS";

            if (model != null && ModelState.IsValid)
            {
                var bTS = mapper.Map<BTS>(model);
                await service.AddAsync(bTS);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View("NotFound");
            }

        }
    }
}