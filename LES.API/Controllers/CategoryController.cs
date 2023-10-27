using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Domain.ViewModels;
using LES.Infrastructure.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace LES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork iUnitOfWork)
        {
            _categoryRepository = categoryRepository;
            _unitOfWork = iUnitOfWork;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Add a new category", Description = "Create a new category.")]
        public async Task Add([FromBody] CategoryViewModel request)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                IsActive = request.IsActive,
            };

            _categoryRepository.Add(category);
            await _unitOfWork.SaveChangesAsync();
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Get all categories", Description = "Retrieve a list of all categories.")]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();

            return Ok(categories);
        }
    }
}
