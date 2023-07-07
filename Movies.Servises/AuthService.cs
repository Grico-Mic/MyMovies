using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.DtoModels;
using MyMovies.Servises.Interfaces;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MyMovies.Servises
{
    public class AuthService : IAuthService
    {
        private IUsersRepository _usersRepository { get; set; }
        public AuthService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public StatusModel SignIn(string username, string password, bool IsPersistent, HttpContext httpContext)
        {
            var response = new StatusModel();
            var user = _usersRepository.GetByUsername(username);
            if (user != null && user.Password == password)
            {
                var claims = new List<Claim>()
                {
                    new Claim("Id",user.Id.ToString()),
                    new Claim("Username",user.Username),
                    new Claim("Address",user.Address),
                    new Claim("Email",user.Email),
                    new Claim("IsAdmin",user.IsAdmin.ToString())

                };

                var identity = new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var authProps = new AuthenticationProperties() { IsPersistent = IsPersistent };

                Task.Run(() => httpContext.SignInAsync(principal, authProps)).GetAwaiter().GetResult();

            }
            else
            {
                response.IsSuccessful = false;
                response.Message = "Invalid username or password.";
            }



            return response;
        }

        public void SignOut(HttpContext httpContext)
        {
            Task.Run(() => httpContext.SignOutAsync()).GetAwaiter().GetResult();
        }

        public StatusModel SignUp(User toSignUpModel)
        {
            var response = new StatusModel();
            var user =_usersRepository.CheckIfExist(toSignUpModel.Username,toSignUpModel.Email);

            if (user)
            {
                response.IsSuccessful = false;
                response.Message = "User with username or email already exist";
                return response;

            }
                var newUser = new User()
                {
                    Username = toSignUpModel.Username,
                    Email = toSignUpModel.Email,
                    Address = toSignUpModel.Address,
                    Password = toSignUpModel.Password,
                    DateCreated = DateTime.Now
                };

            _usersRepository.Add(newUser);

           
            return response;
        }
    }
   
}
