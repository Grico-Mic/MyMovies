using MyMovies.Models;
using System.Collections.Generic;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
       User GetById(int userId);
        bool CheckIfExist(string username, string email);
        void Add(User newUser);
        List<User> GetAll();
        void Update(User user);
        void Delete(User user);
    }
}
