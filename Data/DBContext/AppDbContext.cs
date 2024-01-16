using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}

