using System.Threading.Tasks;
using LoggingPOC.Enums;
using LoggingPOC.Helpers;
using LoggingPOC.Logging;
using Microsoft.AspNetCore.Http;

namespace LoggingPOC.Middlewares
{
    /// <summary>
    /// This middleware is used to catch every method call
    /// </summary>
    public class CustomMiddleware
    {
        private readonly RequestDelegate _next;
        private          ILogService     _logService;

        public CustomMiddleware(RequestDelegate next)
        {
            _next   = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            var flowId = FlowIdHelper.SetFlowId(httpContext.Request.Path.Value);
            _logService = (ILogService) httpContext.RequestServices.GetService(typeof(ILogService));
            _logService.Info("{FlowStatus} middleware operation {FlowId}", FlowStatus.Start, flowId);
            await _next(httpContext);
            _logService.Info("{FlowStatus} middleware operation {FlowId}", FlowStatus.End, flowId);
        }

    }
}