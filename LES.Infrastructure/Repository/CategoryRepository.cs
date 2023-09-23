using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
    public class CategoryRepository : RepositoryBase<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
    }
}
