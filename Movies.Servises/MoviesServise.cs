using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.Interfaces; 
using System.Collections.Generic;


namespace Movies.Servises
{
    public class MoviesServise : IMoviesServise
    {
        private IMoviesRepository _moviesRepository { get; set; }
        public MoviesServise(IMoviesRepository moviesRepository)
        {
            _moviesRepository = moviesRepository;
        }

        public List<Movie> GetAllMovies()
        {
            return _moviesRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }

        public void CreateMovie(Movie movie)
        {
            _moviesRepository.Create(movie);
        }
    }
       
}
  