using Microsoft.EntityFrameworkCore;
using Multishop.Order.Domain.Entities;

namespace Multishop.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;Initial Catalog=MultishopOrderDb;User=sa;Password=4675190Aa**");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Ordering> Orderings { get; set; }
    }
}
