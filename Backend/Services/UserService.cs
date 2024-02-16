using Backend.Database;
using Backend.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Backend.Services
{
    public class UserService
    {
        private readonly LoginDB _context;

        public UserService(LoginDB context)
        {
            _context = context;
        }

        public bool IsValidUser(string document, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Document == document && u.Password == password);
            return user != null;
        }
    }
}