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
    public class PersonController : BaseController
    {
        private readonly IMediator mediator1;

        public PersonController(IMediator mediator, IMediator mediator1) : base(mediator1)
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
        /// مشاهده همه افراد
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [ValidateModel]
        [HttpGet("GetPersons")]
        public async Task<IActionResult> GetPersons([FromBody] PersonQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


        /// <summary>
        /// مشاهده فرد بر اساس ایدی
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetPersonById")]
        public async Task<IActionResult> GetPersonById([FromBody] PersonByIdQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


        /// <summary>
        /// افزودن فرد
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddPerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddPerson([FromBody] AddPersonCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

        /// <summary>
        /// ویرایش فرد
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdatePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

        /// <summary>
        /// حذف فرد
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemovePerson")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemovePerson([FromBody] RemovePersonCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }

    }
}
