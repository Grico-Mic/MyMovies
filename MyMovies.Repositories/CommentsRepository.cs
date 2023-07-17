using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Repositories
{
    public class CommentsRepository : BaseRepository<Comment> , ICommentsRepository
    {
        public CommentsRepository(MyMoviesDbContext context) : base(context)
        {

        }
    }
}
