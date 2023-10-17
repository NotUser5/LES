using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
	public class ProductRepository : RepositoryBase<Product, Guid>, IProductRepository
	{
		public ProductRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
		
	}
}