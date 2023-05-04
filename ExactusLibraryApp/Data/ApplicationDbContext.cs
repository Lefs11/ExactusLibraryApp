using ExactusLibraryApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ExactusLibraryApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<BookType> BookTypes { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Book> Books { get; set; }
    }
}
