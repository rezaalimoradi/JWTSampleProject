using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace JWTSampleProject.Infrastructure.Base
{
    public class BaseController : Controller
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public async Task<IActionResult> ExecuteTResponse<TResponse>(IRequest<TResponse> request)
        {
            return Ok(new
            {
                data = await _mediator.Send(request),
                StatusCode = true
            });
        }
    }
}
