using LES.Domain.Models;
using LES.Infrastructure.Data;

namespace LES.Infrastructure.Repository
{
    public class CategoryRepository : RepositoryBase<Category, Guid>, ICategoryRepository
    {
        public CategoryRepository(DataContext applicationDataContext) : base(applicationDataContext)
        {
        }
    }
}
