using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Policy = "IsAdmin")]
    public class MoviesController : Controller
    {
       
        public IMoviesServise _servise { get; set; }
        public MoviesController(IMoviesServise service)
        {
            _servise = service;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
           var movies =  _servise.GetMovieByTitle(title);
           

            var overviewDataModel = new MovieOverviewDataModel();

            var moviesOverviewModel = movies.Select(x => x.ToOverviewModel()).ToList();

            overviewDataModel.OverviewMovies = moviesOverviewModel;

            List<Movie> mostRecentMovies = _servise.GetMostRecentMovies(5);
            overviewDataModel.SidebarData.MostRecentRecipes = mostRecentMovies.Select(x => x.ToSidebarModel()).ToList();

            List<Movie> getTopMovies = _servise.GetTopMovies(5);
            overviewDataModel.SidebarData.TopRecipes = getTopMovies.Select(x => x.ToSidebarModel()).ToList();

            return View(overviewDataModel);

        }
      
        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;

            var movies = _servise.GetAll();
            var viewModels = movies.Select(x => x.ToManageOverviewModel()).ToList();
            return View(viewModels);
        }
        [AllowAnonymous]
        public IActionResult Details(int id)
        { 
            try
            {
                var movie = _servise.GetMovieDetails(id);
              
                if (movie == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var movieDataModel = new MoviesDetailsDataModel();

                 movieDataModel.MovieDetails = movie.ToDetailsModel();

                var mostRecentMovies = _servise.GetMostRecentMovies(5);
                var getTopMovies = _servise.GetTopMovies(5);

                movieDataModel.MovieSidebar.MostRecentRecipes = mostRecentMovies.Select(x => x.ToSidebarModel()).ToList();
                movieDataModel.MovieSidebar.TopRecipes = getTopMovies.Select(x => x.ToSidebarModel()).ToList();

                return View(movieDataModel);
            }
            catch (Exception )
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
                var response = _servise.Delete(id);
                if (response.IsSuccessful)
                {
                return RedirectToAction("ManageOverview", new { SuccessMessage = "The movie was deleted successfully." });
                }
                else
                {
                return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }
            catch (Exception)
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
                   
                   var response =  _servise.Update(movie.ToUpdateModel());
                    if (response.IsSuccessful)
                    {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "The movie was updated successfully." });
                    }
                    else
                    {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                    }
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
