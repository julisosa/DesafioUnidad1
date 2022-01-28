using DesafiosAPI.Models;
using DesafiosAPI.ViewModels.Auth;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace DesafiosAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public IActionResult Authentication(Login login)
        {
            User user1 = new User();

            user1.Name = "Julieta";
            user1.Password = "kirito";
            user1.Email = "julisoad15@gmail.com";

            if (IsValidUser(login, user1))
            {
                var token = GenerateToken(user1.Name, user1.Email);
                return Ok(new { token });
            }
            return BadRequest("El usuario o la contraseña son incorrectas");
        }

        private bool IsValidUser(Login login, User user)
        {
            if (login.Email.Equals(user.Email) && login.Password.Equals(user.Password))
            {
                return true;
            }

            return false;
        }

        private string GenerateToken(string name, string email)
        {
            //Headereader
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:SecretKey"]));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var header = new JwtHeader(signingCredentials);

            //Claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email)
            };

            //Payload
            var payload = new JwtPayload
            (
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claims,
                DateTime.Now,
                DateTime.UtcNow.AddMinutes(2)
            );

            var token = new JwtSecurityToken(header, payload);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
