﻿using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LES.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClientController : ControllerBase
	{
		private readonly IClientRepository _clientRepository;
		private readonly IUnitOfWork _uow;

		public ClientController(IClientRepository clientRepository, IUnitOfWork uow)
		{
			_clientRepository = clientRepository;
			_uow = uow;
		}

		[HttpPost]
		public async Task CreateClient([FromBody] Client client)
		{
			_clientRepository.Add(client);
			await _uow.SaveChangesAsync();
		}

		[HttpGet]
		public async Task<IActionResult> GetClients()
		{
			return Ok(await _clientRepository.GetAll());
		}

		[HttpGet("{id}")]
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
		public async Task<IActionResult> DeleteClient(Guid id)
		{
			var client = _clientRepository.GetById(id);
			if (client == null)
			{
				return NotFound();
			}

			client.Active = false;

			_uow.SaveChangesAsync();
			return NoContent();
		}
	}
}