using Azure.Core;
using JWTSampleProject.ControllerFilters;
using JWTSampleProject.Core.Commands;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Infrastructure.Base;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Caching.Memory;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace JWTSampleProject.Controllers
{
    [EnableCors("AllowOrigin")]
    [NotImplExceptionFilter]
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseController
    {
        private const string productCacheKey = "product";
        private IMemoryCache _cache;
        private ILogger<ProductController> _logger;
        private readonly IMediator mediator1;

        public ProductController(IMemoryCache cache,
        ILogger<ProductController> logger, IMediator mediator1) : base(mediator1)
        {
            this.mediator1 = mediator1;
            _cache = cache ?? throw new ArgumentNullException(nameof(cache));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
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
        public async Task<IActionResult> GetProducts([FromBody] ProductQueryInputModel inputModel)
        {
            _logger.Log(LogLevel.Information, "Trying to fetch the list of product from cache.");

            if (_cache.TryGetValue(productCacheKey, out IEnumerable<Product> products))
            {
                _logger.Log(LogLevel.Information, "product list found in cache.");
                return await ExecuteTResponse(inputModel);
            }

            else
            {
                _logger.Log(LogLevel.Information, "product list not found in cache. Fetching from database.");
                var res = await mediator1.Send(inputModel);
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                        .SetSlidingExpiration(TimeSpan.FromSeconds(60))
                        .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                        .SetPriority(CacheItemPriority.Normal)
                        .SetSize(1024);
                _cache.Set(productCacheKey, products, cacheEntryOptions);
                return Ok(new
                {
                    data = res,
                    StatusCode = true
                });
            }
            return null;
        }


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
