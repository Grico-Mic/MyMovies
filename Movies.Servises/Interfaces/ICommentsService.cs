using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Servises.Interfaces
{
    public interface ICommentsService
    {
        void Add(string comment, int movieId, int userId);
    }
}
