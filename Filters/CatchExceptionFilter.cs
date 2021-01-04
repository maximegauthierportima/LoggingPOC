using System;
using System.Net;
using System.Threading.Tasks;
using LoggingPOC.Logging;
using LoggingPOC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoggingPOC.Filters
{
    /// <summary>
    /// Filter that catch Exceptions globally
    /// </summary>
    public class CatchExceptionFilter: IAsyncExceptionFilter
    {
        public CatchExceptionFilter(ILogService logService)
        {
            _logService = logService;
        }
        private readonly ILogService _logService;

        public Task OnExceptionAsync(ExceptionContext context)
        {
            SetLoggingLevelAndMessage(context);
            context.Result = SetResponse(context);
            return Task.CompletedTask;
        }

        /// <summary>
        /// Set the response send to the client
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        private IActionResult SetResponse(ExceptionContext context)
        {
            //Business exception-More generics for external world
            var errorResponse = new ErrorResponse();
            switch (context.Exception)
            {
                case ArgumentNullException _:
                    errorResponse.StatusCode = HttpStatusCode.BadRequest;
                    errorResponse.Message        = "Error 400 thrown from CatchExceptionAttribute";
                    break;
                default:
                    errorResponse.StatusCode = HttpStatusCode.InternalServerError;
                    errorResponse.Message        = "Error 500 thrown from CatchExceptionAttribute";
                    break;
            }

            context.Result = new JsonResult(errorResponse);
            
            return context.Result;
        }

        /// <summary>
        /// Set the logging level and the message inside the log
        /// </summary>
        /// <param name="context"></param>
        private void SetLoggingLevelAndMessage(ExceptionContext context)
        {
            switch (context.Exception)
            {
                case ArgumentNullException _:
                    _logService.Warn("A non-critical error occured in {@Action} {@Exception} {@EventProperties}", context.ActionDescriptor.DisplayName, context.Exception, context.ActionDescriptor.BoundProperties);
                    break;
                default:
                    _logService.Error("An error occured in {@Action} {@EventProperties}", context.Exception, context.ActionDescriptor.Properties);
                    break;
            }
        }
    }
}
