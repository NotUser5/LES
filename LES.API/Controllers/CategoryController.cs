using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Domain.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace LES.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUnitOfWork _iUnitOfWork;

        public CategoryController(ICategoryRepository categoryRepository, IUnitOfWork iUnitOfWork)
        {
            _categoryRepository = categoryRepository;
            _iUnitOfWork = iUnitOfWork;
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CategoryViewModel request)
        {
            // Map ViewModel to Domain Model
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Description = request.Description,
                IsActive = request.IsActive,
            };

            _categoryRepository.Add(category);

            // Domain model to ViewModel
            var response = new CategoryViewModel
            {
                Id = category.Id,
                Description = category.Description,
                IsActive = category.IsActive
            };

            return Ok(response);
        }

        // GET: https://localhost:7107/api/Category
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _categoryRepository.GetAll();

            // Map Domain model to DTO

            //var response = new List<CategoryDto>();
            //foreach (var category in caterogies)
            //{
            //    response.Add(new CategoryDto
            //    {
            //        Id = category.Id,
            //        Name = category.Name,
            //        UrlHandle = category.UrlHandle
            //    });
            //}

            return Ok(categories);
        }
    }
}
