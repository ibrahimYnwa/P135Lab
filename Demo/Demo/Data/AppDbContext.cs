using Demo.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<BookGenre> BookGenres { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<SocialPage> SocialPages { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}
