using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class PostService
    {
        private readonly PostRepository _PostRepository;

        public PostService(PostRepository PostRepository)
        {
            _PostRepository = PostRepository;
        }

        public List<Post> GetPosts()
        {
            return _PostRepository.GetAllPosts();
        }

        public Post GetPostById(string postId)
        {
            return _PostRepository.GetPostById(postId);
        }

        public List<Post> GetPostsByUserId(int userId, bool isStory)
        {
            return _PostRepository.GetPostsByUserId(userId, isStory);
        }
    }
}
