using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class CommentService
    {
        private readonly CommentRepository _CommentRepository;

        public CommentService(CommentRepository CommentRepository)
        {
            _CommentRepository = CommentRepository;
        }

        public List<Comment> GetComments()
        {
            return _CommentRepository.GetAllComments();
        }

        public void AddComment(Comment comment)
        {
            _CommentRepository.AddComment(comment);
        }

    }
}
