using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
	public class OrderRepository : RepositoryBase<Order, Guid>, IOrderRepository
	{
		public OrderRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
		
	}
}