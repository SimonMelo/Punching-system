using System;
using Backend.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [ApiController]
    [Route("loginAuth")]

    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            if (IsValidUser(login.Document, login.Password))
            {
                var token = GenerateJwtToken(login.Document);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private bool IsValidUser(string? Document, string? Password)
        {
            if (string.IsNullOrEmpty(Document) || string.IsNullOrEmpty(Password))
            {
                return false;
            }

            if (Document != "30030030030")
            {
                return false;
            }

            return (Password == "senha123");
        }

        private string GenerateJwtToken(string? Document)
        {

            if (Document == null)
            {
                throw new ArgumentNullException(nameof(Document), "Document cannot be null.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7b4e943e0d59c10f4a7a5d3f9d0f0b28c92a526af8475f2ebda4d7f53023cbdb"));

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, Document) },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}