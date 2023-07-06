using MyMovies.Models;
using MyMovies.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyMovies.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private MyMoviesDbContext _context;

        public UsersRepository(MyMoviesDbContext context)
        {
           _context = context;
        }

        public void Add(User newUser)
        {
            _context.Add(newUser);
            _context.SaveChanges();
        }

        public bool CheckIfExist(string username, string email)
        {
            return _context.Users.Any(x => x.Username == username || x.Email == email);
        }

        public User GetById(int userId)
        {
            return _context.Users.FirstOrDefault(x => x.Id == userId);
        }

        public User GetByUsername(string username)
        {
           return  _context.Users.FirstOrDefault(x => x.Username == username);
        }

       
        

       
    }
}
