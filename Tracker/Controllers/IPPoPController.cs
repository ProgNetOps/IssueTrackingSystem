using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class IPPoPController : Controller
    {
        private readonly IIPPoPService service;
        private readonly IMapper mapper;

        public IPPoPController(IIPPoPService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "IP PoPs";

            var ipPoPs = await service.GetAllAsync();
            var ipPoPsDTO = mapper.Map<IEnumerable<IPPoPDTO?>>(ipPoPs);
            return View(ipPoPsDTO);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "IP PoP";

            var ipPoP = await service.GetByIdAsync(id);
            if (ipPoP != null)
            {
                var ipPoPDTO = mapper.Map<IPPoPDTO>(ipPoP);
                return View(ipPoPDTO);
            }
            else
            {
                return View(nameof(NotFound));
            }
        }
    }
}
