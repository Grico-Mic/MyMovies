using Microsoft.AspNetCore.Mvc;
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
