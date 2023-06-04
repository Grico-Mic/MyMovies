using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Models;
using MyMovies.Servises.Interfaces;
using System;

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
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var recipes = _servise.GetAllMovies();
            return View(recipes);
        }
        public IActionResult Details(int id)
        {
            try
            {
                var movie = _servise.GetMovieById(id);

                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }
                return View(movie);
            }
            catch (System.Exception ex)
            {

                return RedirectToAction("ErrorGeneral", "Info");
            }
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
                return RedirectToAction("ManageOverview", new { SuccessMessage = "The movie was created successfully."});
            }
            
            return View(movie);
        }

        public IActionResult Delete(int id)
        {
            try
            {
                _servise.Delete(id);
                return RedirectToAction("ManageOverview", new { SuccessMessage = "The movie was deleted successfully." });
            }
            catch (NotFoundException ex)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = ex.Message });
                //return RedirectToAction("ActionNotSuccessfull", "Info", new { Message = ex.Message});
            }
            catch (Exception ex)
            {
                return RedirectToAction("InternalError", "Info");
            }
           
        }
    }
}
