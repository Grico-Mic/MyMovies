using Microsoft.EntityFrameworkCore;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : BaseRepository<Movie>, IMoviesRepository
    {
        
        public MoviesRepository(MyMoviesDbContext context): base(context)
        {
            
        }

        public List<Movie> GetMovieByTitle(string title)
        {
            
            return _context.MyMovies.Where(x => x.Title.Contains(title)).ToList();
        }

        public override Movie GetById(int entityId)
        {
            return _context.MyMovies
                .Include(x => x.Comments)
                .ThenInclude(x => x.User)
                .FirstOrDefault(x => x.Id == entityId);
        }
    } 
}
