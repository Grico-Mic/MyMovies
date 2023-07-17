using Microsoft.EntityFrameworkCore;
using MyMovies.Models;

namespace MyMovies.Repositories
{
    public class MyMoviesDbContext : DbContext
    {
        public MyMoviesDbContext(DbContextOptions<MyMoviesDbContext> options): base(options)
        {

        }

        public DbSet<Movie> MyMovies { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}
