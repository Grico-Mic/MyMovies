using MyMovies.Models;

namespace MyMovies.Repositories.Interfaces
{
    public interface IUsersRepository
    {
        User GetByUsername(string username);
       User GetById(int userId);
    }
}
