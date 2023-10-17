using LES.Domain.Core.Data;
using LES.Domain.Models;

namespace LES.Infrastructure.Repository.Interfaces
{
	public interface IProductRepository : IRepository<Product, Guid> { }
}