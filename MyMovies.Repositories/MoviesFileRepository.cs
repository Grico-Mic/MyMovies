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
        const string Path = "Movies.txt";
        public MoviesFileRepository()
        {
            if (!File.Exists(Path))
            {
                File.WriteAllText(Path, "[]");
            }

            var result = File.ReadAllText(Path);
            var deserialzedList = JsonConvert.DeserializeObject<List<Movie>>(result);
            Movies = deserialzedList;
        }
        public List<Movie> Movies { get; set; }

       

        public void Create(Movie movie)
        {
          
            movie.Id = GenerateId();
            Movies.Add(movie);
            SaveChanges();
        }

        private int GenerateId()
        {
            var maxId = 0;

            if (Movies.Any())
            {
                maxId = Movies.Max(x => x.Id);

            }
            return maxId + 1; 
        }

        public List<Movie> GetAll()
        {
            return Movies;
        }

        public Movie GetById(int id)
        {
            return Movies.FirstOrDefault(x => x.Id == id);
        }

        private void SaveChanges()
        {
            var seriliazed = JsonConvert.SerializeObject(Movies);
            File.WriteAllText(Path, seriliazed);
        }
    }
}
