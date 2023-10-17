using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interface;

namespace LES.Infrastructure.Repository
{
	public class UserRepository : RepositoryBase<User, Guid>, IUserRepository
    {
        public UserRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
    }
}
