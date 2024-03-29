using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Multishop.Discount.Entities;
using System.Data;

namespace Multishop.Discount.Context
{
    public class DapperContext : DbContext
    {
        //Dapper configras methodunun tanımlanması
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Initial Catalog=MultiShopDiscountDB;uid=sa;pwd=4675190;");
        }

        public DbSet<Coupon> Coupons { get; set; }
        public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
    }
}
