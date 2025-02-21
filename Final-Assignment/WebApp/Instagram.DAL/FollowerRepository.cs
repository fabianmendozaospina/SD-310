using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.DAL
{
    public class FollowerRepository
    {
        private readonly InstagramContext _context;

        public FollowerRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<Follower> GetAllFollowers()
        {
            return _context.Followers.ToList();
        }

        public List<Follower> GetFollowersByUserId(int userId)
        {
            return _context.Followers
                .Where(f => f.UserId == userId)
                .Include(f => f.User) 
                .Include(f => f.FollowerNavigation) 
                .ToList();
        }
    }
}
