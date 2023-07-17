using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Repositories
{
    public class UsersRepository : BaseRepository<User>, IUsersRepository
    {
        
        public UsersRepository(MyMoviesDbContext context) : base(context)
        {
          
        }
        
        public bool CheckIfExist(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }
        public User GetByUsername(string username)
        {
           return  _context.Users.FirstOrDefault(x => x.Username == username);
        }
    }
}
