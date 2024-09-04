using System.Net;

namespace JWTSampleProject.Infrastructure.Base
{
    public class ExceptionMiddleware
    {
        //به خاطر همین next در نظر میگیریم که شبیه next در behavior ها هست
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate request)
        {
            _next = request;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {

                await HandleException(httpContext, ex);
            }
        }

        private async Task HandleException(HttpContext httpContext, Exception exception)
        {
            httpContext.Response.StatusCode = (int)(HttpStatusCode.InternalServerError);
            httpContext.Response.ContentType = "application/json";
            await httpContext.Response.WriteAsync("{\"data\" : \""+ exception.Message + "\",\"status\" : false}");
        }
    }
}
