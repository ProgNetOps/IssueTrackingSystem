using Microsoft.AspNetCore.Mvc;
using Tracker.Services.Services;

namespace Tracker.Controllers
{
    public class DCNRouterController : Controller
    {
        private readonly IDCNRouterService service;

        public DCNRouterController(IDCNRouterService service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
