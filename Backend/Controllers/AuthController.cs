using Microsoft.AspNetCore.Mvc;
using Backend.Models;
using Backend.Services;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace Backend.Controllers
{
    [ApiController]
    [Route("loginAuth")]
    public class AuthController : ControllerBase
    {
        private readonly UserService _userService;

        public AuthController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("login")]
        public IActionResult Login(LoginModel login)
        {
            if (_userService.IsValidUser(login.Document, login.Password))
            {
                var token = GenerateJwtToken(login.Document);
                return Ok(new { token });
            }

            return Unauthorized();
        }

        private string GenerateJwtToken(string? document) // Ajuste do nome do parâmetro
        {
            if (document == null)
            {
                throw new ArgumentNullException(nameof(document), "Document cannot be null.");
            }

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("7b4e943e0d59c10f4a7a5d3f9d0f0b28c92a526af8475f2ebda4d7f53023cbdb"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                claims: new[] { new Claim(ClaimTypes.Name, document) },
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
