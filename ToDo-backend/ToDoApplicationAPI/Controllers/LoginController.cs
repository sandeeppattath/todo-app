using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ToDoApplicationAPI.Models;

namespace ToDoApplicationAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly TokenSettings _tokenSettings;

        public LoginController(TokenSettings tokenSettings)
        {
            _tokenSettings = tokenSettings;
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            // Validate the user credentials 
            if (request.Username == "testuser" && request.Password == "testpassword")
            {
                var claims = new[]
                {
                new Claim(JwtRegisteredClaimNames.Sub, request.Username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSettings.SecretKey));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: _tokenSettings.Issuer,
                    audience: _tokenSettings.Audience,
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(_tokenSettings.ExpirationInMinutes),
                    signingCredentials: creds);

                var tokenString = new JwtSecurityTokenHandler().WriteToken(token);

                return Ok(new LoginResponse
                {
                    Token = tokenString,
                    Expiration = token.ValidTo
                });
            }

            return Unauthorized();
        }
    }
}
