using JWTSampleProject.ControllerFilters;
using JWTSampleProject.CQRS.InputModel;
using MediatR;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc.Filters;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using JWTSampleProject.Context;
using JWTSampleProject.Models;

namespace JWTSampleProject.Controllers
{
    [ApiController]
    [EnableCors("AllowOrigin")]
    [NotImplExceptionFilter]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;
        private readonly ISampleDbContext _context;

        public LoginController(ILogger<LoginController> logger, IConfiguration configuration,IMediator mediator, ISampleDbContext context)
        {
            _logger = logger;
            _configuration = configuration; 
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] UserByIdQueryInputModel inputModel) =>
                    Ok(new
                    {
                        data = await _mediator.Send(inputModel),
                        StatusCode = true
                    });

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginInputModel model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _context.Users.FindAsync(model.Id);
                if (currentUser != null && currentUser.Email != model.Username) 
                {
                    return Unauthorized();
                }
                if (currentUser.Role != "admin")
                {
                    return Unauthorized();
                }
                if (currentUser != null && currentUser.Email == model.Username && currentUser.Role == "admin")
                {
                    var issuer = _configuration["Jwt:Issuer"];
                    var audience = _configuration["Jwt:Audience"];
                    var key = _configuration["JWT:Key"];
                    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        { new Claim("id", model.Username)
                        }),
                        Expires = DateTime.Now.AddMinutes(10),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)

                    };
                    var tokenObject = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
                    var ResultJwt = new JwtSecurityTokenHandler().WriteToken(tokenObject);
                    if (ResultJwt == null) return Unauthorized();
                    return Ok(ResultJwt);
                }
            }
            return Unauthorized();
        }
    }
}
