using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interfaces;

namespace LES.Infrastructure.Repository
{
    public class ClientRepository : RepositoryBase<Category, Guid>, IClientRepository
	{
		public ClientRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
	}
}