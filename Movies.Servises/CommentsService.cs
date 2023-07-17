using MyMovies.Models;
using MyMovies.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Servises
{
    public class CommentsService
    {
        private readonly CommentsRepository _commentsRepository;
        public CommentsService(CommentsRepository commentsRepository)
        {
            commentsRepository = _commentsRepository;
        }

        public List<Comment> GetAll()
        {
            return _commentsRepository.GetAll();
        }
    }
}
