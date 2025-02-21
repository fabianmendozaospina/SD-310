using Instagram.Models;

namespace Instagram.DAL
{
    public class LikeRepository
    {
        private readonly InstagramContext _context;

        public LikeRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<Like> GetAllLikes()
        {
            return _context.Likes.ToList();
        }

        public void UpdateReaction(Like reaction)
        {
            Like current = _context.Likes.FirstOrDefault(u => u.UserId == reaction.UserId && u.PostId == reaction.PostId);

            if (current == null)
            {
                _context.Likes.Add(reaction);
            }
            else
            {
                _context.Likes.Remove(current);
            }

            _context.SaveChanges();
        }
    }
}
