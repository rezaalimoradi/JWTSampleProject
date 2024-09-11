using JWTSampleProject.ControllerFilters;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Infrastructure.Base;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace JWTSampleProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [NotImplExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class EducationController : BaseController
    {
        private readonly IMediator mediator1;

        public EducationController(IMediator mediator, IMediator mediator1) : base(mediator1)
        {
            this.mediator1 = mediator1;
        }

        //after
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string jtiClaimValue = null;
            if (context.HttpContext.User.Claims.Any(a => a.Type == "jti"))
            {
                jtiClaimValue = context.HttpContext.User.Claims.FirstOrDefault(a => a.Type == "jti").Value;
            }
            int userid = !string.IsNullOrWhiteSpace(jtiClaimValue) ? int.Parse(jtiClaimValue) : -1;
            //_logger.OperationInsertIntoLoanServiceHisoty(Request.Path.ToString(), context.HttpContext.Request.Headers["RequestDate"].ToString(), DateTime.Now.ToString(), userid);
        }

        //before
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //start
            context.HttpContext.Request.Headers.Add("RequestDate", new Microsoft.Extensions.Primitives.StringValues(DateTime.Now.ToString()));

        }


        /// <summary>
        /// مشاهده همه مقاطع تحصیلی
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [ValidateModel]
        [HttpGet("GetEducation")]
        public async Task<IActionResult> GetEducation([FromBody] EducationQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


        /// <summary>
        /// مشاهده مقاطع تحصیلی بر اساس ایدی
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetEducationById")]
        public async Task<IActionResult> GetPersonById([FromBody] EducationByIdQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


        /// <summary>
        /// افزودن مقاطع تحصیلی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddEducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddEducation([FromBody] AddEducationCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

        /// <summary>
        /// ویرایش مقاطع تحصیلی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdateEducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateEducation([FromBody] UpdateEducationCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

        /// <summary>
        /// حذف مقاطع تحصیلی
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemoveEducation")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveEducation([FromBody] RemoveEducationCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

    }
}
