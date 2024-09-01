using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc.Filters;

namespace KarafariniPlans.ControllerFilters
{
    public class RequestLogFilter : IActionFilter
    {
        private readonly ILogger<RequestLogFilter> _logger;
        public RequestLogFilter(ILogger<RequestLogFilter> logger)
        {
            _logger = logger;
        }
        public void OnActionExecuted(ActionExecutedContext context)
        {
            // For now we dont need it
        }

        public async void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogTrace(
                $"Request is received on action. method: {context.HttpContext.Request.Method}, controller: {context.Controller} url: {context.HttpContext.Request.Path}",
                context?.HttpContext?.Request?.Method,
                context?.Controller?.GetType(),
                context?.HttpContext?.Request?.GetDisplayUrl(),
                context?.ActionArguments);
        }
    }
}
