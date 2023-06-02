using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class MoviesRepository : IMoviesRepository
    {
        private MyMoviesDbContext _context { get; set; }
        public MoviesRepository(MyMoviesDbContext context)
        {
            _context = context;
        }

        public void Create(Movie movie)
        {
            _context.Add(movie);
            _context.SaveChanges();
        }
        public void Delete(Movie movie)
        {
            _context.MyMovies.Remove(movie);
            _context.SaveChanges();
        }
        public void Update(Movie movie)
        {
            _context.MyMovies.Update(movie);
            _context.SaveChanges();
        }
        public List<Movie> GetAll()
        {
            var movies = _context.MyMovies.ToList();
            return movies;
        }

        public Movie GetById(int id)
        {
            var movies = _context.MyMovies.FirstOrDefault(x => x.Id == id);
            return movies;
        }
        public List<Movie> GetMovieByTitle(string title)
        {
            var movies = _context.MyMovies.Where(x => x.Title.Contains(title)).ToList();
            return movies;
        }
    }
}
