using DesafioUnidad1.Models;
using Microsoft.EntityFrameworkCore;

namespace DesafioUnidad1
{
    internal class DesafioContext : DbContext
    {
        public DbSet<Comments> Comments { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=Desafio;Trusted_Connection=True;");
        }
    }
}
