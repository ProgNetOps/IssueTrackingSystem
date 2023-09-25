using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tracker.Controllers
{
    public class ErrorController : Controller
    {
        //When a user tries to navigate to a URL that does not match any route in the application
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            var statusCodeResult = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            switch (statusCode)
            {
                case 401:
                    ViewData["ErrorMessage"] = "Sorry, you are not authorized to access the resource";
                    break;

                case 404:
                    ViewData["ErrorMessage"] = "Sorry, the requested resource could not be found";
                    //logger.LogWarning($"404 error occured. Path = {statusCodeResult.OriginalPath}" +
                    //    $" and QueryString = {statusCodeResult.OriginalQueryString}");
                    break;
            }
            return View("NotFound");
        }


        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            //logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
            //    $"{exceptionDetails.Error}");

            return View();
        }
    }
}
