using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
    [SwaggerOperation(Summary = "Create Order", Description = "Create a new order.")]
    public async Task CreateClient([FromBody] Order order)
	{
		_orderRepository.Add(order);
		await _uow.SaveChangesAsync();
	}

	[HttpGet]
    [SwaggerOperation(Summary = "Get all orders", Description = "Retrieve a list of all available orders.")]
    public async Task<IActionResult> GetClients()
	{
		return Ok(_orderRepository.GetAll());
	}

	[HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get order by ID", Description = "Retrieve an order by its ID.")]
    [SwaggerResponse(200, "Success: Returns the order")]
    [SwaggerResponse(404, "Not found: Order not found")]
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
    [SwaggerOperation(Summary = "Update Order", Description = "Update an order by ID")]
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
    [SwaggerOperation(Summary = "Delete Order", Description = "Delete an order by ID")]
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
