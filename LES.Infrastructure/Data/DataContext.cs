using LES.Domain.Core.Data;
using LES.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LES.Infrastructure.Data
{
    public class DataContext : DbContext, IUnitOfWork
    {
		protected readonly IConfiguration _configuration;

		public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration) : base(options) {
			_configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
		{
			options.UseSqlServer(_configuration.GetConnectionString("WebApiDatabase"));
		}

		public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Client> Users { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Order> Orders { get; set; }
	}
}
