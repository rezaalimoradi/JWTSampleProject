using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace JWTSampleProject.ControllerFilters
{
    public class CustomAuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        private IConfiguration _configuration;
        private ILogger<CustomAuthorizeAttribute> _logger;

        public CustomAuthorizeAttribute()
        {
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            _configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            _logger = context.HttpContext.RequestServices.GetRequiredService<ILogger<CustomAuthorizeAttribute>>();
            var jwtIssuer = _configuration.GetSection("Jwt:Issuer").Get<string>();
            var jwtKey = _configuration.GetSection("Jwt:Key").Get<string>();
            var jwtAudeince = _configuration.GetSection("Jwt:Audience").Get<string>();

            context.Result = new UnauthorizedResult();

            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();

                var jwtToken = tokenHandler.ReadToken(context.HttpContext.Request.Headers.Authorization.ToString().Remove(0, 7)) as JwtSecurityToken;

                if (jwtToken == null)
                    context.Result = new UnauthorizedResult();

                var validationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtAudeince,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };

                SecurityToken securityToken;
                var principal = tokenHandler.ValidateToken(context.HttpContext.Request.Headers.Authorization.ToString().Remove(0, 7), validationParameters, out securityToken);

                if (securityToken != null)
                {
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"login failed for {context.HttpContext.Request.Path} {context.HttpContext.Request.Method} {(context.HttpContext.Request.Body == null ? string.Empty : context.HttpContext.Request.Body.ToString())}");
            }
        }


    }
}
