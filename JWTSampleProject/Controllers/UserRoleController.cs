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
    [ApiController]
    [EnableCors("AllowOrigin")]
    [NotImplExceptionFilter]
    [Route("[controller]")]
    public class UserRoleController : BaseController
    {
        private readonly IMediator mediator1;

        public UserRoleController(IMediator mediator, IMediator mediator1) : base(mediator)
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
        /// مشاهده کاربران
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserRoles")]
        public async Task<IActionResult> GetUserRoles([FromBody] UserRoleQueryInputModel inputModel) => await ExecuteTResponse(inputModel);

        /// <summary>
        /// مشاهده کاربر جاری
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetCurrentUserRole")]
        public async Task<IActionResult> GetCurrentUserRole([FromBody] UserRoleCurrentQueryInputModel inputModel) => await ExecuteTResponse(inputModel);

        /// <summary>
        /// مشاهده کاربر
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserRoleById")]
        public async Task<IActionResult> GetUserRoleById([FromBody] UserByIdQueryInputModel inputModel) => await ExecuteTResponse(inputModel);

        /// <summary>
        /// مشاهده کاربر با یوزر و پسورد
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserRoleByRoleOrUser")]
        public async Task<IActionResult> GetUserRoleByRoleOrUser([FromBody] UserRoleByRoleOrUserQueryInputModel inputModel) => await ExecuteTResponse(inputModel);

        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddUserRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUserRole([FromBody] AddUserRoleCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }
        /// <summary>
        /// ویرایش کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdateUserRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUserRole([FromBody] UpdateUserRoleCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }
        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemoveUserRole")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveUserRole([FromBody] RemoveUserRoleCommand command)
        {
            await mediator1.Send(command);

            return Ok();
        }
    }
}
