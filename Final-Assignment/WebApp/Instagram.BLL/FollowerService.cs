using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class FollowerService
    {
        private readonly FollowerRepository _FollowerRepository;

        public FollowerService(FollowerRepository FollowerRepository)
        {
            _FollowerRepository = FollowerRepository;
        }

        public List<Follower> GetFollowers()
        {
            return _FollowerRepository.GetAllFollowers();
        }

        public List<Follower> GetFollowersByUserId(int userId)
        {
            return _FollowerRepository.GetFollowersByUserId(userId);
        }

        public List<Follower> GetUsersByFollowerId(int followerId)
        {
            return _FollowerRepository.GetUsersByFollowerId(followerId);
        }
    }
}
