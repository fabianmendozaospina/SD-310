using Instagram.BLL;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class LikeController : Controller
    {
        private readonly LikeService _likeService;

        public LikeController(LikeService likeService)
        {
            _likeService = likeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Reaction(int userId, string postId)
        {
            if (ModelState.IsValid)
            {
                var reaction = new Like
                {
                    UserId = userId,
                    PostId = postId,
                };

                _likeService.UpdateReaction(reaction);
            }

            return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
