using MyMovies.Models;
using MyMovies.Repositories;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.Interfaces;
using System;
using System.Collections.Generic;

namespace MyMovies.Servises
{
    public class CommentsService :ICommentsService
    {
        private readonly ICommentsRepository _commentsRepository;
        public CommentsService(ICommentsRepository commentsRepository)
        {
            _commentsRepository = commentsRepository;
        }

        

        public void Add(string comment, int movieId, int userId)
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
    }
}
