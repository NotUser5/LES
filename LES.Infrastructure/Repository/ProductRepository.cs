using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
	public class ProductRepository : RepositoryBase<Category, Guid>, IProductRepository
	{
		public ProductRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
	}
}