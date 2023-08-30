using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Common.Exceptions;
using MyMovies.Common.Models;
using MyMovies.Common.Services;
using MyMovies.Mappings;
using MyMovies.Models;
using MyMovies.Services;
using MyMovies.Services.Interfaces;
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
        private readonly ILogService _logService;
        private IMoviesServise _servise { get; set; }
        private ISidebarService _sidebarServise { get; set; }
        public MoviesController(IMoviesServise service , ISidebarService _sidebarService, ILogService logService)
        {
            _servise = service;
            _sidebarServise = _sidebarService;
            _logService = logService;
        }
        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
          

           var movies =  _servise.GetMovieByTitle(title);
           

            var overviewDataModel = new MovieOverviewDataModel();

            var moviesOverviewModel = movies.Select(x => x.ToOverviewModel()).ToList();

            overviewDataModel.OverviewMovies = moviesOverviewModel;

            
            overviewDataModel.SidebarData = _sidebarServise.GetSidebarData();

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

                
                movieDataModel.MovieSidebar = _sidebarServise.GetSidebarData();

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

                var userId = User.FindFirst("Id");
                var logData = new LogData() { Type = LogType.Info , DateCreated = DateTime.Now, Message = $"User with id {userId} created new movie with title {movie.Title}."} ;
                _logService.Log(logData);
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
