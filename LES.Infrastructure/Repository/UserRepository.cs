using LES.Domain.Models;
using LES.Infrastructure.Data;
using LES.Infrastructure.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LES.Infrastructure.Repository
{
    public class UserRepository : RepositoryBase<Category, Guid>, IUserRepository
    {
        public UserRepository(DataContext applicationDataContext) : base(applicationDataContext) { }
    }
}
