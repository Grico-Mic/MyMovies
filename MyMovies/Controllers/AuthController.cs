using Microsoft.AspNetCore.Mvc;
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
        public IActionResult SignOut()
        {
            _authService.SignOut(HttpContext);
            return RedirectToAction("Overview", "Movies");
           
        }
        [HttpPost]
        public IActionResult SignIn(AuthSignInModel authSignInModel,string returnUrl)
        {
            if (ModelState.IsValid)
            {
               var response = _authService.SignIn(authSignInModel.Username, authSignInModel.Password,authSignInModel.IsPersistent, HttpContext);
                if (response.IsSuccessful == true)
                {
                    if (returnUrl == null)
                    {
                return RedirectToAction("Overview", "Movies");

                    }
                    else
                    {
                        return Redirect(returnUrl);
                    }
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
 