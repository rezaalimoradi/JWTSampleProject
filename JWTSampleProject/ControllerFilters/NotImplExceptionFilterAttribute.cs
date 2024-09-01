using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Web.Http.Filters;

namespace KarafariniPlans.ControllerFilters
{
    public class NotImplExceptionFilterAttribute : System.Web.Http.Filters.ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            if (context.Exception is NotImplementedException)
            {
                context.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
        }
    }
}
