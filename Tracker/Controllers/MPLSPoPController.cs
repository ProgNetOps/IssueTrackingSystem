using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Tracker.Entity;
using Tracker.Models.DTOs;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class MPLSPoPController : Controller
    {
        private readonly IMPLSPoPService service;
        private readonly IMapper mapper;

        public MPLSPoPController(IMPLSPoPService service, IMapper mapper)
        {
            this.service = service;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "MPLS PoPs";

            var mplsPoPs = await service.GetAllAsync();
            var mplsPoPDTOs = mapper.Map<IEnumerable<MPLSPoPDTO>>(mplsPoPs);
            return View(mplsPoPDTOs);
        }

        public async Task<IActionResult> Details(int id)
        {
            ViewData["Title"] = "MPLS PoP Details";

            var mplsPoP = await service.GetByIdAsync(id);
            var mplsPoPDTO = mapper.Map<MPLSPoPDTO>(mplsPoP);
            return View(mplsPoPDTO);
        }
    }
}
