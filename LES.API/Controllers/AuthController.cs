using LES.Domain.Models;
using LES.Domain.ViewModels;
using LES.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public static User user = new User();
        private readonly IConfiguration _configuration;
        private readonly DataContext _dataContext;

        public AuthController(IConfiguration configuration, DataContext dataContext)
        {
            _configuration = configuration;
            _dataContext = dataContext;
        }

        [HttpPost("register")]
        public ActionResult<User> Register(UserViewModel request)
        {
            if (_dataContext.Users.Any(u => u.Email == request.Email))
            {
                return BadRequest("User already exists.");
            }

            string passwordHash
                = BCrypt.Net.BCrypt.HashPassword(request.Password);

            User newUser = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Password = passwordHash,
                Cpf = request.Cpf,
                Birthdate = request.Birthdate
            };

            _dataContext.Users.Add(newUser);
            _dataContext.SaveChanges();

            return Ok(newUser);
        }

        [HttpPost("login")]
        public ActionResult<User> Login(UserViewModel request)
        {
            var user = _dataContext.Users.FirstOrDefault(u => u.Email == request.Email);

            if (user.Email != request.Email)
            {
                return BadRequest("User not found.");
            }

            if (!BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
            {
                return BadRequest("Wrong password.");
            }

            string token = CreateToken(user);

            return Ok(token);
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin"),
                new Claim(ClaimTypes.Role, "User"),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuration.GetSection("AppSettings:Token").Value!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddDays(1),
                    signingCredentials: creds
                );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }
    }
}
