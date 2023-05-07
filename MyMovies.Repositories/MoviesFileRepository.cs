using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MyMovies.Repositories
{
    public class MoviesFileRepository : IMoviesRepository
    {
        public MoviesFileRepository()
        {
            var path = "Movies.txt";

            if (!File.Exists(path))
            {
                File.WriteAllText(path, "[]");
            }

            var result = File.ReadAllText(path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Movie>>(result);
            Movies = deserialzedList;
        }
        public List<Movie> Movies { get; set; }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }
    }
}
