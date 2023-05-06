using MyMovies.Models;
using MyMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Movies.Servises
{
    public class MoviesServise
    {
        private MoviesRepository _moviesRepository { get; set; }
        public MoviesServise()
        {
            _moviesRepository = new MoviesRepository();
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }
    }
       
}
  