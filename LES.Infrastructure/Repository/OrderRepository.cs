using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
	public class OrderRepository : RepositoryBase<Category, Guid>, IOrderRepository
	{
		public OrderRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
	}
}