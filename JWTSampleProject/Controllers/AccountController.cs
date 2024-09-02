﻿using JWTSampleProject.ControllerFilters;
using JWTSampleProject.Core.Services.Commands.GeneralData;
using JWTSampleProject.CQRS.InputModel;
using JWTSampleProject.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

        /// <summary>
        /// مشاهده کاربران
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUsers")]
        public async Task<IActionResult> GetUsers([FromBody] UserQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر جاری
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser([FromBody] UserCurrentQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserById")]
        public async Task<IActionResult> GetUserById([FromBody] UserByIdQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });

        /// <summary>
        /// مشاهده کاربر با یوزر و پسورد
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpGet("GetUserByUserPass")]
        public async Task<IActionResult> GetUserByUserPass([FromBody] UserByEmailPassQueryInputModel inputModel) =>
            Ok(new
            {
                data = await _mediator.Send(inputModel),
                StatusCode = true
            });


        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("AddUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> AddUser([FromBody] AddUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// ویرایش کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("UpdateUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [Authorize]
        [ValidateModel]
        [HttpPost("RemoveUser")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> RemoveProduct([FromBody] RemoveUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }


        /// <summary>
        /// لاگین
        /// </summary>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        //[ValidateModel]
        //[HttpGet("Login")]
        //public async Task<User> Login([FromBody] UserByIdQueryInputModel inputModel)
        //{
        //    var obj = await _mediator.Send(inputModel);
        //    User loginRequest = new User{
        //        Email = obj.Email,
        //        PassWord = obj.PassWord,
        //        Role = obj.Role,
        //        UserId = obj.UserId,
        //        BirthDate = obj.BirthDate,
        //        FirstName = obj.FirstName,
        //        LastName = obj.LastName,
        //        IsActive = obj.IsActive,
        //        Phone = obj.Phone
        //    };
        //    this.Login(loginRequest);
        //    return obj;
        //}
        /// <summary>
        /// لاگین
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //[ValidateModel]
        //[HttpPost]
        //[Route("Login")]
        //public IActionResult Login([FromBody] User request)
        //{
        //    UserByEmailPassQueryInputModel userByIdQueryInputModel = new UserByEmailPassQueryInputModel();
        //    userByIdQueryInputModel.Email = request.Email;
        //    userByIdQueryInputModel.PassWord = request.PassWord;
        //    var result = GetUserByUserPass(userByIdQueryInputModel);

        //    var response = new Dictionary<string, string>();
        //    if (!(request.Role == "admin"))
        //    {
        //        response.Add("Error", "Invalid username or password Or Role");
        //        return BadRequest(response);
        //    }

        //    var roles = new string[] { "Role1", "Role2" };
        //    var token = GenerateJwtToken(request.Email, roles.ToList());
        //    return Ok(new LoginResponse()
        //    {
        //        Access_Token = token,
        //        UserName = request.Email
        //    });
        //}


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UsersLoginModel model)
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


        /// <summary>
        /// ساخت توکن
        /// </summary>
        /// <param name="username"></param>
        /// <param name="roles"></param>
        /// <returns></returns>
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

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("YourSecretKeyYourSecretKeyForAuthenticationOfYourSecretKeyForAuthenticationOfApplicationApplicationForAuthenticationOfApplication"));
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

    public class UsersLoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
