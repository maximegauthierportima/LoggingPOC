using System.Diagnostics;
using LoggingPOC.Enums;
using LoggingPOC.Helpers;
using LoggingPOC.Logging;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace LoggingPOC.Attributes
{
    /// <summary>
    /// This attribute will log every action from a controller
    /// </summary>
    public class LoggerAttribute : TypeFilterAttribute
    {
        public LoggerAttribute() : base(typeof(LoggerFilter))
        {
        }

        /// <summary>
        /// This class allows us to use Dependency Injection in attribute
        /// </summary>
        private class LoggerFilter : ActionFilterAttribute
        {
            private readonly ILogService _logService;

            public LoggerFilter(ILogService logService)
            {
                _logService = logService;
            }


            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var flowId = FlowIdHelper.SetFlowId(context.HttpContext.Request.Path.Value);
                _logService.Info(new
                                 {
                                     FlowStatus = FlowStatus.Start.ToString(),
                                     FlowId = flowId,
                                     Method     = context.ActionDescriptor.DisplayName
                                 });
                _logService.Info("Another way of log with properties {FlowStatus} {FlowId} {Method}",
                                 FlowStatus.Start.ToString(), flowId, context.ActionDescriptor.DisplayName);
                context.ActionDescriptor.Properties[context.ActionDescriptor.DisplayName] = Stopwatch.StartNew();
            }

            public override void OnActionExecuted(ActionExecutedContext context)
            {
                var flowId = FlowIdHelper.SetFlowId(context.HttpContext.Request.Path.Value);
                var stopWatch =
                    (Stopwatch) context.ActionDescriptor.Properties
                        [context.ActionDescriptor.DisplayName];
                stopWatch.Stop();
                _logService.Info(new
                                 {
                                     FlowStatus           = FlowStatus.End.ToString(),
                                     FlowId               = flowId,
                                     Method               = context.ActionDescriptor.DisplayName,
                                     ExecutionTimeElapsed = stopWatch.ElapsedMilliseconds
                                 });
                _logService.Info("Another way of log with properties {FlowStatus} {FlowId} {Method} {ExecutionTimeElapsed}",
                                 FlowStatus.End.ToString(), flowId, context.ActionDescriptor.DisplayName,
                                 stopWatch.ElapsedMilliseconds);
            }
        }
    }
}