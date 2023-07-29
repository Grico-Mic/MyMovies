using System;

namespace MyMovies.ViewModels
{
    public class MovieCommentModel
    {
        public string Message { get; set; }
        public string Username { get; set; }
        public DateTime DateCreated { get; set; }
    }
}