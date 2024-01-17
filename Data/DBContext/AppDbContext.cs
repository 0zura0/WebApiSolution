using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.DBContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("BooksDatabase");
        }

        public DbSet<Product> products { get; set; }
        public DbSet<Category> categories { get; set; }
    }
}

