using Microsoft.EntityFrameworkCore;
using Telegramm_Bot_ToDo.Entities;

namespace Telegramm_Bot_ToDo.DataContext
{
    public class AppDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("...");
        }

        public virtual DbSet<ToDos> ToDo { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
