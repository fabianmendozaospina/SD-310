using Instagram.Models;

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
            return _context.Followers.Where(u => u.UserId == userId).ToList();
        }
    }
}
