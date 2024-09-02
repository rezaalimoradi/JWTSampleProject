using JWTSampleProject.ControllerFilters;
using JWTSampleProject.Core.Services.Commands.GeneralData;
using JWTSampleProject.CQRS.InputModel;
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
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public UserController(ILogger<UserController> logger, IConfiguration configuration, IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration;
            _mediator = mediator;
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
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromBody] UserQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر جاری
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser([FromBody] UserCurrentQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] UserByIdQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر با یوزر و پسورد
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserByUserPass")]
        public async Task<IActionResult> GetUserByUserPass([FromBody] UserByEmailPassQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });


        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// ویرایش کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemoveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}
