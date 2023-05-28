using MyMovies.Models;
using System.Collections.Generic;


namespace MyMovies.Servises.Interfaces
{
   public  interface IMoviesServise
    {
        public List<Movie> GetAllMovies();
        public List<Movie> GetMovieByTitle(string title);
        public Movie GetMovieById(int id);
        void CreateMovie(Movie movie);
    }
}
