﻿using MyMovies.Models;
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
    }
}
