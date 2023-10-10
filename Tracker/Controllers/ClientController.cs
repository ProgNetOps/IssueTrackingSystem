using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientService service;
        private readonly IMapper mapper;

        public ClientController(IClientService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string? searchBy = null, string? searchString = null, int pageNumber = 1, int pageSize = 100)
        {
            ViewData["Title"] = "Clients";

            //SEARCH
            ViewBag.SearchFields = new Dictionary<string, string>()
            {
                { nameof(ClientDTO.ClientName), "Client Name" }
            };

            var clients = await service.GetFilteredResultAsync(searchBy, searchString, pageNumber, pageSize);

            //To persist the last search values on the view
            ViewBag.currentSearchBy = searchBy;
            ViewBag.currentSearchString = searchString;

            var clientsDTO = mapper.Map<IEnumerable<ClientDTO?>>(clients);
            return View(clientsDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "Client";

            var client = await service.GetByIdAsync(id);
            var clientDTO = mapper.Map<ClientDTO>(client);
            return View(clientDTO);
        }
    }
}
