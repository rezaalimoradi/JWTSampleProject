using JWTSampleProject.CQRS.InputModel;
using KarafariniPlans.Core.Services.Commands.GeneralData;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTSampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }
        /// <summary>
        /// مشاهده همه محصولات
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
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
        [HttpPost("RemoveProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveProductCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }

    }
}
