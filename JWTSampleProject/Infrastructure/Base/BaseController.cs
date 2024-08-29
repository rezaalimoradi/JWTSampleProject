using Microsoft.AspNetCore.Mvc;

namespace JWTSampleProject.Infrastructure.Base
{
    public class BaseController : Controller
    {
        public async Task<IActionResult> Execute<TResponse>(IAPIResult<TResponse> inputModel)
        {
            return Ok();
        }
    }
}
