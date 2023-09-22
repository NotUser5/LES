using LES.Domain.Core.Data;
using LES.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace LES.Infrastructure.Data
{
    public class ApplicationDataContext : DbContext, IUnitOfWork
    {
        public ApplicationDataContext(DbContextOptions<ApplicationDataContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
