using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using Why.Data.Models;

namespace Why.Data
{
    public class WhyDbContext : DbContext
    {
      
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EIGJ1QA;Database=WhyDb;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        //public WhyDbContext(DbContextOptions option) : base(option)
        //{

        //}
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Thumb> Thumbs { get; set; }
        public DbSet<Biography> Biographies { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}
