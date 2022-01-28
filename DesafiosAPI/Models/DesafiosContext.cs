using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DesafiosAPI.Models
{
    public class DesafiosContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DesafiosContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:Desafios"]);
        }

        public DbSet<Comments> Comments { get; set; }

        public DbSet<Posts> Posts { get; set; }

        public DbSet<User> Users { get; set; }

    }
}
