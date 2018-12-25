using AutoMapper;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Sgs.Library.Mvc.Controllers
{
    public class ErrorsController:BaseController
    {
        public ErrorsController(IMapper mapper
            , ILogger<ErrorsController> logger) : base(mapper, logger)
        {
        }

        [Route("Error/500")]
        public IActionResult Error500()
        {
            var exceptionFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            this._logger.LogError($"Error at {exceptionFeature?.Path ?? "No path data"} - error message : {exceptionFeature?.Error?.Message ?? "No error data"}.");
            ViewBag.StatusCode = 500;
            ViewBag.ErrorMessage = "Sorry something went wrong on the server !!. Please try again later .. ";
            return View("Error");
        }

        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();
            ViewBag.StatusCode = statusCode;
            if (statusCode == 404)
            {
                this._logger.LogWarning($"Request to {statusCodeData.OriginalPath}{statusCodeData.OriginalQueryString} - {statusCodeData.OriginalPathBase} not found");
                ViewBag.ErrorMessage = "Sorry we can't find the requsted page or data !!. Please try again later .. ";
            }
            else
            {
                this._logger.LogError($"Something went wrong on the server status code : {statusCode} .  path : {statusCodeData.OriginalPath}{statusCodeData.OriginalQueryString} - {statusCodeData.OriginalPathBase} ");
                ViewBag.ErrorMessage = "Sorry something went wrong on the server !!. Please try again later .. ";
            }

            return View("Error");
        }
    }
}
