using JWTSampleProject.CQRS.InputModel;
using MediatR;
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

        [HttpGet("[action]")]
        public async Task<IActionResult> GetProducts([FromBody] ProductQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });
    }
}
