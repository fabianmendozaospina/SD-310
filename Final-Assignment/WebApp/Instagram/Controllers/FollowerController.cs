using Instagram.BLL;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class FollowerController : Controller
    {
        private readonly FollowerService _followerService;

        public FollowerController(FollowerService followerService)
        {
            _followerService = followerService;
        }

        public IActionResult Index()
        {
            List<Follower> followers = _followerService.GetFollowers();

            return View(followers);
        }

        public IActionResult Followers(int id)
        {
            List<Follower> followers = _followerService.GetFollowersByUserId(id);

            return View(followers);
        }
    }
}
