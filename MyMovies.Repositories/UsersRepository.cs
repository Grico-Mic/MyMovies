using MyMovies.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class UsersRepository
    {
        private MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
            this._context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}
