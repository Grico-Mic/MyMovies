using MyMovies.Models;

namespace MyMovies.Servises.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
      
    }
}
