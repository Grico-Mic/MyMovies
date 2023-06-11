using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Servises.Interfaces;
using MyMovies.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

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
            var listOverviewModel = new List<MovieOverviewModel>();

            var moviesOverviewModel = movies.Select(x => x.ToOverviewModel()).ToList();
            return View(moviesOverviewModel);

        }
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var movies = _servise.GetAllMovies();
            var viewModels = movies.Select(x => x.ToManageOverviewModel()).ToList();
            return View(viewModels);
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
                return View(movie.ToDetailsModel());
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
        public IActionResult Create(MovieCreateModel movie)
        {
            if (ModelState.IsValid)
            {
                var domainModel = movie.ToModel();
                _servise.CreateMovie(domainModel);
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
        [HttpGet]
        public IActionResult Update(int id)
        {
           var movie =  _servise.GetMovieById(id);
            if (movie == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = "Movie not found." });
            }
            return View(movie.ToUpdateModel());
        }
        [HttpPost]
        public IActionResult Update(MovieUpdateModel movie)
        {

            if (ModelState.IsValid)
            {
                try
                {
                   
                    _servise.Update(movie.ToUpdateModel());
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "The movie was updated successfully." });
                }
                catch (NotFoundException ex)
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = ex.Message });
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError", "Info");
                }
                
            }

            return View(movie);
        }
    }
}
