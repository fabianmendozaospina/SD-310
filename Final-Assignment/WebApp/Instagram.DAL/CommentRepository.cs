using Instagram.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Instagram.DAL
{
    public class CommentRepository
    {
        private readonly InstagramContext _context;

        public CommentRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<Comment> GetAllComments()
        {
            return _context.Comments.ToList();
        }
        public void AddComment(Comment comment)
        {
            Comment current = _context.Comments.FirstOrDefault(c => c.UserId == comment.UserId && c.PostId == comment.PostId && c.CommentText == comment.CommentText);

            if (current == null)
            {
                try
                {
                    comment.CommentId = 0;
                    comment.Timestamp = DateTime.Now;
                    _context.Comments.Add(comment);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    throw;
                }
            }
        }
    }
}
