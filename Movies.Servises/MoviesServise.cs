using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.DtoModels;
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

        public List<Movie> GetAll()
        {
            return _moviesRepository.GetAll();
        }

        public Movie GetMovieById(int id)
        {
            return _moviesRepository.GetById(id);
        }

        public Movie GetMovieDetails(int id)
        {
            var movie = GetMovieById(id);
            if (movie == null)
            {
                return movie;
            }
            movie.Views ++;
            _moviesRepository.Update(movie);
            return movie;
            
        }

        public void CreateMovie(Movie movie)
        {
            movie.DateCreated = DateTime.Now;
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

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
           var movie =  _moviesRepository.GetById(id);

            if (movie == null)
            {
                response.IsSuccessful = false;
                response.Message = "The movie that you want to delete doesn't not exist.";
            }
            else
            {
                _moviesRepository.Delete(movie);
               
            }
            
                return response;
            
        }

        public StatusModel Update(Movie movie)
        {
            var response = new StatusModel();
            var updatedMovie = _moviesRepository.GetById(movie.Id);
            if (updatedMovie != null)
            {
                updatedMovie.Title = movie.Title;
                updatedMovie.Description = movie.Description;
                updatedMovie.Ganre = movie.Ganre;
                updatedMovie.ImageURL = movie.ImageURL;
                updatedMovie.DateUpdated = DateTime.Now;

                _moviesRepository.Update(updatedMovie);
               
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "The movie that you want to update was no found.";
            }
            return response;
        }

        public List<Movie> GetMostRecentMovies(int count)
        {
            return  _moviesRepository.GeMostRecentMovies(count);
           
        }

        public List<Movie> GetTopMovies(int count)
        {
            return _moviesRepository.GetTopMovies(count);
        }
    }  
}
  