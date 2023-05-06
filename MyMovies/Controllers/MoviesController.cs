using Microsoft.AspNetCore.Mvc;
using Movies.Servises;
using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public MoviesServise _servise { get; set; }
        public MoviesController()
        {
            _servise = new MoviesServise();
        }

        public IActionResult Overview()
        {
           var movies =  _servise.GetAllMovies();
           return View(movies);
        }

        public IActionResult Details(int id)
        {
            var movie = _servise.GetMovieById(id);

        if (movie == null)
        {
            return RedirectToAction("ErrorNotFound", "Info");
        }

        return View(movie);
        }
    
    }
}
