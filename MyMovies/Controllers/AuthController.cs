﻿using Microsoft.AspNetCore.Mvc;
using MyMovies.Servises.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class AuthController : Controller
    {
        public IAuthService _authService { get; set; }
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignIn(AuthSignInModel authSignInModel)
        {
            if (ModelState.IsValid)
            {
               var response = _authService.SignIn(authSignInModel.Username, authSignInModel.Password,HttpContext);
                if (response.IsSuccessful == true)
                {
                return RedirectToAction("Overview", "Movies");
                }
                else
                {
                    ModelState.AddModelError("", response.Message);
                    return View(authSignInModel);
                }
            }
            return View(authSignInModel);
        }  
    }
}
 