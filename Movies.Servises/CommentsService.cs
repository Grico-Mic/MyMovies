using Movies.Servises;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.DtoModels;
using MyMovies.Servises.Interfaces;
using System;

namespace MyMovies.Servises
{
    public class CommentsService :ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        private readonly IMoviesServise _moviesServise;
        public CommentsService(ICommentsRepository commentsRepository, IMoviesServise moviesService)
        {
            _commentsRepository = commentsRepository;
            _moviesServise = moviesService;
        }

        

        public StatusModel Add(string comment, int movieId, int userId)
        {
            var response = new StatusModel();
            var movies = _moviesServise.GetMovieById(movieId);

            if (movies != null)
            {
                var newComment = new Comment()
                {
                    Message = comment,
                    MovieId = movieId,
                    UserId = userId,
                    DateCreated = DateTime.Now
                };
                _commentsRepository.Create(newComment);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The movie with id {movieId} was not found";
            }
            return response;
        }
    }
}
