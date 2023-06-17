using Microsoft.AspNetCore.Http;
using MyMovies.Servises.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Servises.Interfaces
{
    public interface IAuthService
    {
         StatusModel SignIn(string username, string password, HttpContext httpContext);
    }
}
