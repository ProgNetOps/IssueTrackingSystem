using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.DTOs;
using Tracker.Persistence;
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
               
        public async Task<IActionResult> Index (string? searchBy = null, string? searchString = null, int pageNumber = 1, int pageSize = 100)
        {
            ViewData["Title"] = "Base Stations";

            //SEARCH
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(BTSDTO.BTSName), "Site Id" },
                { nameof(BTSDTO.LocationAddress), "Address" },
                { nameof(BTSDTO.State.StateName), "State" }
            };

            var BaseStations = await service.GetFilteredResultAsync(searchBy, searchString, pageNumber, pageSize);

            //To persist the last search values on the view
            ViewBag.currentSearchBy = searchBy;
            ViewBag.currentSearchString = searchString;

            var BaseStationsDTO = mapper.Map<IEnumerable<BTSDTO>>(BaseStations);
            return View(BaseStationsDTO);
        }


        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "BTS";

            var baseStation = await service.GetByIdAsync(id);
            if (baseStation != null)
            {
                var baseStationDTO = mapper.Map<BTSDTO>(baseStation);
                return View(baseStationDTO);
            }
            else
            {
                return View(nameof(NotFound));
            }
        }

        public async Task<IActionResult> Create(BTSCreateDTO model)
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
                return View(model);
            }

        }
    }
}