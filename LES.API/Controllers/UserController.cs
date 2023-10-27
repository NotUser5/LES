using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Repository.Interface;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LES.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _clientRepository;
		private readonly IUnitOfWork _uow;

		public UserController(IUserRepository clientRepository, IUnitOfWork uow)
		{
			_clientRepository = clientRepository;
			_uow = uow;
		}

		[HttpPost]
        [SwaggerOperation(Summary = "Create a new client", Description = "Create a new client.")]
        public async Task CreateClient([FromBody] User client)
		{
			_clientRepository.Add(client);
			await _uow.SaveChangesAsync();
		}

		[HttpGet]
        [SwaggerOperation(Summary = "Get all clients", Description = "Retrieve a list of all clients.")]
        public async Task<IActionResult> GetClients()
		{
			return Ok(await _clientRepository.GetAll());
		}

		[HttpGet("{id}")]
        [SwaggerOperation(Summary = "Get client by ID", Description = "Retrieve a client by its ID.")]
        public async Task<IActionResult> GetClientById(Guid id)
		{
			var client = _clientRepository.GetById(id);
			if (client == null)
			{
				return NotFound();
			}
			return Ok(client);
		}

		[HttpPut("{id}")]
        [SwaggerOperation(Summary = "Update a client", Description = "Update a client by ID")]
        public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Client updatedClient)
		{
			var client = _clientRepository.GetById(id);
			if (client == null)
			{
				return NotFound();
			}

			client.FirstName = updatedClient.FirstName;
			client.LastName = updatedClient.LastName;

			await _uow.SaveChangesAsync();
			return NoContent();
		}

		[HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Delete a client", Description = "Delete a client by ID")]
        public async Task<IActionResult> DeleteClient(Guid id)
		{
			var client = _clientRepository.GetById(id);
			if (client == null)
			{
				return NotFound();
			}
			
			_uow.SaveChangesAsync();
			return NoContent();
		}
	}
}