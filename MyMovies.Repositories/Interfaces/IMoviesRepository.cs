using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        public Movie GetById(int id);
        public List<Movie> GetAll();
    }
}
