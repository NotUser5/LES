using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Domain.ViewModels;
using LES.Infrastructure.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LES.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IConfiguration _configuration;
		private readonly IUserRepository _userRepository;
		private readonly IUnitOfWork _uow;

		public AuthController(IConfiguration configuration, IUnitOfWork uow, IUserRepository user)
		{
			_configuration = configuration;
			_uow = uow;
			_userRepository = user;
		}

		[HttpPost("register")]
        [SwaggerOperation(Summary = "Register a new user", Description = "Registers a new user.")]
        public async Task<IActionResult> Register(UserViewModel request)
		{
			var user = await _userRepository.GetAll();

			var teste = user.ToList().FirstOrDefault(f => f.Email.Equals(request.Email));

			if (teste != null) { return BadRequest("User already exists."); }

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

			_userRepository.Add(newUser);
			await _uow.SaveChangesAsync();

			return Ok(newUser);
		}

		[HttpPost("login")]
        [SwaggerOperation(Summary = "Login for authentication", Description = "Authenticates a user.")]
        public async Task<IActionResult> Login(UserViewModel request)
		{
			var user = await _userRepository.GetAll();

			var teste = user.ToList().FirstOrDefault(a => a.Email.Equals(request.Email));

			if (!BCrypt.Net.BCrypt.Verify(request.Password, teste.Password))
			{
				return BadRequest("Wrong password.");
			}

			string token = CreateToken(teste);

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
