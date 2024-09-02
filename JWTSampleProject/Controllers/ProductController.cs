using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.ControllerFilters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using JWTSampleProject.Core.Services.Commands.GeneralData;
using Microsoft.AspNetCore.Cors;

namespace JWTSampleProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [NotImplExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
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
        /// مشاهده همه محصولات
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [ValidateModel]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromBody] ProductQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });


        /// <summary>
        /// مشاهده همه محصولات یک کاربر
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetProductsById")]
        public async Task<IActionResult> GetProductsById([FromBody] ProductByIdQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });


        /// <summary>
        /// افزودن محصول
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// ویرایش محصول
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdateProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// حذف محصول
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemoveProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

    }
}
