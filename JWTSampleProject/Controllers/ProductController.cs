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
    public class ProductController : BaseController
    {
        private readonly IMediator mediator1;

        public ProductController(IMediator mediator, IMediator mediator1) : base(mediator1)
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
        /// مشاهده همه محصولات
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [ValidateModel]
        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromBody] ProductQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


        /// <summary>
        /// مشاهده همه محصولات یک کاربر
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetProductsById")]
        public async Task<IActionResult> GetProductsById([FromBody] ProductByIdQueryInputModel inputModel) => await ExecuteTResponse(inputModel);


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
            await mediator1.Send(command);

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
            await mediator1.Send(command);

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
            await mediator1.Send(command);

            return Ok();
        }

    }
}
