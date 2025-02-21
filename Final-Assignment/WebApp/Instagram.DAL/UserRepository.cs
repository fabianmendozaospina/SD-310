using System.Linq;
using Instagram.Models;

namespace Instagram.DAL
{
    public class UserRepository
    {
        private readonly InstagramContext _context;

        public UserRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int userId)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == userId);
        }
    }
}
