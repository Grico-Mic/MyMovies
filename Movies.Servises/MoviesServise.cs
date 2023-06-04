using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.Interfaces;
using System;
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

        public List<Movie> GetMovieByTitle(string title)
        {
            if (title == null)
            {
                return _moviesRepository.GetAll();
            }
            else
            {
                return _moviesRepository.GetMovieByTitle(title);
            }
        }

        public void Delete(int id)
        {
           var movie =  _moviesRepository.GetById(id);

            if (movie == null)
            {
                throw new NotFoundException($"The movie that you want to delete doesn't not exist.");
            }
            else
            {
                _moviesRepository.Delete(movie);
            }
        }

       
    }
       
}
  