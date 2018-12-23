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

            if (exceptionFeature != null)
            {
                this._logger.LogError($"Error at {exceptionFeature.Path} - error message : {exceptionFeature.Error.Message}.");

                //ToDo: Remove in production
                ViewBag.ErrorMessage = exceptionFeature.Error.Message;
                ViewBag.RouteOfException = exceptionFeature.Path;
            }

            return View();
        }

        [Route("Error/{statusCode}")]
        public IActionResult HandleErrorCode(int statusCode)
        {
            var statusCodeData = HttpContext.Features.Get<IStatusCodeReExecuteFeature>();

            switch (statusCode)
            {
                case 404:
                    this._logger.LogError($"Request {statusCodeData.OriginalPath} - {statusCodeData.OriginalPathBase} - {statusCodeData.OriginalQueryString} not found");
                    ViewBag.ErrorMessage = $"Sorry the page you requested could not be found .{statusCodeData.OriginalPath} - {statusCodeData.OriginalPathBase} - {statusCodeData.OriginalQueryString}";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
                case 500:
                    this._logger.LogError($"Sorry something went wrong on the server .  path : {statusCodeData.OriginalPath} - {statusCodeData.OriginalPathBase} - {statusCodeData.OriginalQueryString} ");
                    ViewBag.ErrorMessage = $"Sorry something went wrong on the server. {statusCodeData.OriginalPath} - {statusCodeData.OriginalPathBase} - {statusCodeData.OriginalQueryString}";
                    ViewBag.RouteOfException = statusCodeData.OriginalPath;
                    break;
            }

            return View();
        }
    }
}
