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

        public LoginController(ILogger<LoginController> logger, IConfiguration configuration,IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration; 
            _mediator = mediator;
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginInputModel model)
        {
            if (ModelState.IsValid)
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
            return Unauthorized();
        }
    }
}
