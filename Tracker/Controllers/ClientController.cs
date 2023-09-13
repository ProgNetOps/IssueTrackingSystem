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

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Clients";

            var Clients = await service.GetAllAsync();
            var ClientsDTO = mapper.Map<IEnumerable<ClientDTO>>(Clients);
            return View(ClientsDTO);
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
