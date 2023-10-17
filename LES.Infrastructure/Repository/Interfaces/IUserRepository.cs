using LES.Domain.Core.Data;
using LES.Domain.Models;
using LES.Infrastructure.Data;

namespace LES.Infrastructure.Repository.Interface
{
    public interface IUserRepository : IRepository<User, Guid> { }
}
