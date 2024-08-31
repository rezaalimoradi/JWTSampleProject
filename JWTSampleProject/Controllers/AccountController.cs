using Azure;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTSampleProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMediator _mediator;

        public AccountController(ILogger<AccountController> logger, IConfiguration configuration,IMediator mediator)
        {
            _logger = logger;
            _configuration = configuration; 
            _mediator = mediator;
        }


        [HttpGet("[action]")]
        public async Task<IActionResult> GetUsers([FromBody] UserQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });


        [HttpGet("[action]")]
        public async Task<User> Login([FromBody] UserQueryInputModel inputModel)
        {
            var obj = await _mediator.Send(inputModel);
            User loginRequest = new User{
                Email = obj.Email,
                PassWord = obj.FirstName,
                Role = obj.Role
                
            };
            this.Login(loginRequest);
            return obj;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] User request)
        {
            var response = new Dictionary<string, string>();
            if (!(request.Role == "admin"))
            {
                response.Add("Error", "Invalid username or password Or Role");
                return BadRequest(response);
            }

            var roles = new string[] { "Role1", "Role2" };
            var token = GenerateJwtToken(request.Email, roles.ToList());
            return Ok(new LoginResponse()
            {
                Access_Token = token,
                UserName = request.Email
            });
        }

        private string GenerateJwtToken(string username, List<string> roles)
        {
            var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, username)
        };

            roles.ForEach(role =>
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            });

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JwtKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expires = DateTime.Now.AddDays(Convert.ToDouble(_configuration["JwtExpireDays"]));

            var token = new JwtSecurityToken(
                _configuration["JwtIssuer"],
                _configuration["JwtIssuer"],
                claims,
                expires: expires,
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
