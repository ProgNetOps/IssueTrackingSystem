using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class CircuitController : Controller
    {
        private readonly ICircuitService service;
        private readonly IMapper mapper;

        public CircuitController(ICircuitService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string? searchBy = null, string? searchString = null, int pageNumber = 1, int pageSize = 100)
        {
            ViewData["Title"] = "Circuits";

            //SEARCH
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(CircuitDTO.CircuitName), "Name" },
                { nameof(CircuitDTO.ProjectManager), "Project Manager" },
                { nameof(CircuitDTO.AccountManager), "Account Manager" },
                { nameof(CircuitDTO.Address), "Address" },
                { nameof(CircuitDTO.State.StateName), "State" },
                { nameof(CircuitDTO.State.Region.RegionName), "Region" },
                { nameof(CircuitDTO.TAM), "TAM" }
            };

            var circuits = await service.GetFilteredResultAsync(searchBy, searchString, pageNumber, pageSize);

            //To persist the last search values on the view
            ViewBag.currentSearchBy = searchBy;
            ViewBag.currentSearchString = searchString;

            var circuitsDTO = mapper.Map<IEnumerable<CircuitDTO?>>(circuits);
            return View(circuitsDTO);
        }

      

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Circuit";

            var circuit = await service.GetByIdAsync(id);
            var circuitDTO = mapper.Map<CircuitDTO?>(circuit);

            return View(circuitDTO);
        }
    }
}
