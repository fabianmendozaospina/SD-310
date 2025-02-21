using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class LikeService
    {
        private readonly LikeRepository _likeRepository;

        public LikeService(LikeRepository LikeRepository)
        {
            _likeRepository = LikeRepository;
        }

        public List<Like> GetLikes()
        {
            return _likeRepository.GetAllLikes();
        }

        public void UpdateReaction(Like reaction)
        {
            _likeRepository.UpdateReaction(reaction);
        }

    }
}
