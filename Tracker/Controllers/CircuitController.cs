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

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Circuits";
            
            var circuits = await service.GetAllAsync();
            var circuitsDTO = mapper.Map<IEnumerable<CircuitDTO>>(circuits);

            return View(circuitsDTO);
        }
    }
}
