using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using MyMovies.Servises.Interfaces;

namespace MyMovies.Servises
{
    public class UsersService : IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        public UsersService(IUsersRepository usersRepository )
        {
            _usersRepository = usersRepository;
        }

        public User GetDetails(string userId)
        {
            return _usersRepository.GetById(int.Parse(userId));
        }    
    }
}
