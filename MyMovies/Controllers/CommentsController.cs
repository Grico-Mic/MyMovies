using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyMovies.Servises.Interfaces;
using MyMovies.ViewModels;

namespace MyMovies.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ICommentsService _commentsService;
        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }


        [Authorize]
        [HttpPost]
        public IActionResult AddComment(CommentCreateModel commentCreateModel)
        {
            var userId = int.Parse(User.FindFirst("Id").Value);

            var response = _commentsService.Add(commentCreateModel.Comment, commentCreateModel.MovieId, userId);
            if (response.IsSuccessful)
            {
               return RedirectToAction("Details","Movies" ,new {id = commentCreateModel.MovieId });
            }
            else
            {
                return RedirectToAction("ActionNotSuccessfull","Info", new { response.Message});
            }
        }
    }
}
 