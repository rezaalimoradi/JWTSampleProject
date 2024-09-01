using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace JWTSampleProject.ControllerFilters
{
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<HttpGlobalExceptionFilter> _logger;
        private readonly IConfiguration _configuration;


        public HttpGlobalExceptionFilter(IWebHostEnvironment env, ILogger<HttpGlobalExceptionFilter> logger, IConfiguration configuration)
        {
            _env = env;
            _logger = logger;
            _configuration = configuration;
        }

        public void OnException(ExceptionContext context)
        {

            //if (context.Exception.GetType() == typeof(BusinessRuleValidationException))
            //{
            //    _logger.LogError("Business Exception was occurred :", new EventId(context.Exception.HResult),
            //        context.Exception,
            //        context.Exception.Message);

            //    var problemDetails = new ValidationProblemDetails()
            //    {
            //        Instance = context.HttpContext.Request.Path,
            //        Status = StatusCodes.Status409Conflict,
            //        Detail = "Please refer to the errors property for additional details."
            //    };

            //    problemDetails.Errors.Add("DomainValidations", new string[] { context.Exception.Message.ToString() });

            //    context.Result = new BadRequestObjectResult(problemDetails);
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
            //}
            //else
            //{

            //    _logger.LogError("Unknown Exception was occurred :", new EventId(context.Exception.HResult),
            //         context.Exception,
            //         context.Exception.Message);
            //    var json = new JsonErrorResponse
            //    {
            //        Messages = new[] { "An error occurred.Try it again." }
            //    };


            //    if (Convert.ToBoolean(_configuration["DeveloperArea:ReturnReturnExceptionDetails"]))
            //    {
            //        json.DeveloperMessage = context.Exception.ToString();
            //    }
            //    context.Result = new InternalServerErrorObjectResult(json);
            //    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            //}
            //context.ExceptionHandled = true;
        }
    }
}
