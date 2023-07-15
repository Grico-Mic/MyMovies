using MyMovies.Models;
using MyMovies.Servises.DtoModels;
using System.Collections.Generic;

namespace MyMovies.Servises.Interfaces
{
    public interface IUsersService
    {
        User GetDetails(string userId);
        List<User> GetAll();
       StatusModel ToggleAdminRole(int id);
        StatusModel Delete(int id);
    }
}
