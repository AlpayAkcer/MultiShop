using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entities;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Initial Catalog=CommentDb;User=sa;Password=4675190Aa**");
        }

        public DbSet<UserComment> UserComments { get; set; }
    }
}
