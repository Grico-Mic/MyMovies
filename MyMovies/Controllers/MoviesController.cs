using Microsoft.AspNetCore.Mvc;
using MyMovies.Models;
using MyMovies.Servises.Interfaces;


namespace MyMovies.Controllers
{
    public class MoviesController : Controller
    {
        public IMoviesServise _servise { get; set; }
        public MoviesController(IMoviesServise service)
        {
            _servise = service;
        }

        public IActionResult Overview(string title)
        {
           var movies =  _servise.GetMovieByTitle(title);
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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                _servise.CreateMovie(movie);
                return RedirectToAction("Overview");
            }
            
            return View(movie);
        }

    }
}
 