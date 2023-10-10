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

                default:

                    ViewData["ErrorMessage"] = "An error occured, sorry";
                    break;
            }
            return View("NotFound");
        }


        /// <summary>
        /// Action method that handles unhandled exceptions
        /// </summary>
        /// <returns></returns>
        [Route("Error")]
        [AllowAnonymous]
        public IActionResult Error()
        {
            var exceptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionDetails.Path;
            ViewBag.ExceptionMessage = exceptionDetails.Error.Message;
            ViewBag.StackTrace = exceptionDetails.Error.StackTrace;

            //logger.LogError($"The path {exceptionDetails.Path} threw an exception " +
            //    $"{exceptionDetails.Error}");

            return View("Error");
        }
    }
}
