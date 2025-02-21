using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.DAL
{
    public class PostRepository
    {
        private readonly InstagramContext _context;

        public PostRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<Post> GetAllPosts()
        {
            return _context.Posts.ToList();
        }

        public Post GetPostById(string postId)
        {
            return _context.Posts
                .Include(u => u.User)
                .Include(u => u.Images)
                .Include(u => u.Likes)
                .Include(u => u.Comments)
                .FirstOrDefault(u => u.PostId == postId);
        }

        public List<Post> GetPostsByUserId(int userId, bool isStory)
        {
            return _context.Posts
                .Where(u => u.UserId == userId && u.IsStory == isStory)
                .Include(u => u.User)
                .Include(u => u.Images)
                .Include(u => u.Likes)
                .Include(u => u.Comments)
                .ToList();
        }
    }
}
