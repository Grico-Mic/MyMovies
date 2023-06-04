using Microsoft.AspNetCore.Mvc;

namespace MyMovies.Controllers
{
    public class InfoController : Controller
    {
        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult ContactUs()

        {
            return View();
        }

        public IActionResult ErrorNotFound()

        {
            return View();
        }
        public IActionResult ErrorGeneral()

        {
            return View();
        }
        public IActionResult ActionNotSuccessfull(string message)

        {
            ViewBag.Message = message;
            return View();
        }
        public IActionResult InternalError(string message)

        {
            ViewBag.Message = message;
            return View();
        }
    }
}
