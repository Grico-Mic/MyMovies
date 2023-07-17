using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository : IBaseRepository<Movie>
    {
       
        List<Movie> GetMovieByTitle(string title);
     
    }
}
