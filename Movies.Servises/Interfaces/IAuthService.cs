using Microsoft.AspNetCore.Http;
using MyMovies.Models;
using MyMovies.Servises.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyMovies.Servises.Interfaces
{
    public interface IAuthService
    {
         StatusModel SignIn(string username, string password, bool IsPersistent,HttpContext httpContext);
        void SignOut(HttpContext httpContext);
        StatusModel SignUp(User toSignUpModel);
    }
}
