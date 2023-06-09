﻿using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IMoviesRepository
    {
        public Movie GetById(int id);
        public List<Movie> GetAll();
        void Create(Movie movie);
        List<Movie> GetMovieByTitle(string title);
        void Delete(Movie movie);
        void Update(Movie movie);
    }
}
