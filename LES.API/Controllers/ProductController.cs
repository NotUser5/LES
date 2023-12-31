﻿using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Domain.ViewModels;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LES.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductController : ControllerBase
	{
		private readonly IProductRepository _productRepository;
		private readonly IUnitOfWork _unitOfWork;

		public ProductController(IProductRepository productRepository, IUnitOfWork iUnitOfWork)
		{
			_productRepository = productRepository;
			_unitOfWork = iUnitOfWork;
		}

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] Product request)
		{
			var product = new Product
			{
				Id = Guid.NewGuid(),
				Description = request.Description,
				IsActive = request.IsActive,
			};

			_productRepository.Add(product);
			await _unitOfWork.SaveChangesAsync();

			var response = new Product()
			{
				Id = product.Id,
				Description = product.Description,
				IsActive = product.IsActive
			};

			return Ok(response);
		}

		[HttpGet]
		public async Task<IActionResult> GetAllCategories()
		{
			var categories = await _productRepository.GetAll();

			return Ok(categories);
		}
	}
}
