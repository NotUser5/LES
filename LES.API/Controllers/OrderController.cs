using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
	private readonly IUnitOfWork _uow;
	private readonly IOrderRepository _orderRepository;

	public OrderController(IUnitOfWork uow, IOrderRepository orderRepository)
	{
		_uow = uow;
		_orderRepository = orderRepository;
	}

	[HttpPost]
	public async Task CreateClient([FromBody] Order order)
	{
		_orderRepository.Add(order);
		await _uow.SaveChangesAsync();
	}

	[HttpGet]
	public async Task<IActionResult> GetClients()
	{
		return Ok(_orderRepository.GetAll());
	}

	[HttpGet("{id}")]
	public IActionResult GetClientById(Guid id)
	{
		var client = _orderRepository.GetById(id);
		if (client == null)
		{
			return NotFound();
		}
		return Ok(client);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateClient(Guid id, [FromBody] Client updatedClient)
	{
		var order = _orderRepository.GetById(id);
		if (order == null)
		{
			return NotFound();
		}

		//order. = updatedClient.FirstName;
		//client.LastName = updatedClient.LastName;

		await _uow.SaveChangesAsync();
		return NoContent();
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteClient(Guid id)
	{
		var order = _orderRepository.GetById(id);
		if (order == null)
		{
			return NotFound();
		}

		order.Active = false;

		_uow.SaveChangesAsync();
		return NoContent();
	}
}
