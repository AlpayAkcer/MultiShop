using Microsoft.EntityFrameworkCore;
using MultiShop.Message.DAL.Entities;

namespace MultiShop.Message.DAL.Context
{
    public class MessageContext : DbContext
    {
        //npgsql aketini yükledikten sonra configration ayarları yapılacak
        //appsetting kısmına conncetion localhost ayarları yazılacak

        public MessageContext(DbContextOptions<MessageContext> options) : base(options)
        {
        }

        public DbSet<UserMessage> UserMessages { get; set; }
    }
}
