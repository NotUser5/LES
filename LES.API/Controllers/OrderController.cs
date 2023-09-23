//using LES.Domain.Models;
//using Microsoft.AspNetCore.Mvc;

//[Route("api/clients")]
//[ApiController]
//public class OrderController : ControllerBase
//{
//	private readonly AppDbContext _dbContext;

//	public OrderController(AppDbContext dbContext)
//	{
//		_dbContext = dbContext;
//	}

//	// POST: api/clients
//	[HttpPost]
//	public IActionResult CreateClient([FromBody] Client client)
//	{
//		// Add client to the database
//		_dbContext.Clients.Add(client);
//		_dbContext.SaveChanges();
//		return CreatedAtAction("GetClientById", new { id = client.Id }, client);
//	}

//	// GET: api/clients
//	[HttpGet]
//	public IActionResult GetClients()
//	{
//		var clients = _dbContext.Clients.ToList();
//		return Ok(clients);
//	}

//	// GET: api/clients/{id}
//	[HttpGet("{id}")]
//	public IActionResult GetClientById(int id)
//	{
//		var client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
//		if (client == null)
//		{
//			return NotFound();
//		}
//		return Ok(client);
//	}

//	// PUT: api/clients/{id}
//	[HttpPut("{id}")]
//	public IActionResult UpdateClient(int id, [FromBody] Client updatedClient)
//	{
//		var client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
//		if (client == null)
//		{
//			return NotFound();
//		}

//		// Update client properties
//		client.FirstName = updatedClient.FirstName;
//		client.LastName = updatedClient.LastName;
//		// Update other properties as needed

//		_dbContext.SaveChanges();
//		return NoContent();
//	}

//	// DELETE: api/clients/{id}
//	[HttpDelete("{id}")]
//	public IActionResult DeleteClient(int id)
//	{
//		var client = _dbContext.Clients.FirstOrDefault(c => c.Id == id);
//		if (client == null)
//		{
//			return NotFound();
//		}

//		// Perform logical delete by setting isEnabled flag
//		client.IsEnabled = false;

//		_dbContext.SaveChanges();
//		return NoContent();
//	}
//}
