using Instagram.BLL;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class PostController : Controller
    {
        private readonly PostService _postService;
        private readonly ViewService _viewService;

        public PostController(PostService postService, ViewService viewService)
        {
            _postService = postService;
            _viewService = viewService;
        }

        public IActionResult Index()
        {
            List<Post> posts = _postService.GetPosts();

            return View(posts);
        }

        public IActionResult Posts(int id, bool isStory)
        {
            List<Post> posts = _postService.GetPostsByUserId(id, isStory);

            if (posts == null || posts.Count == 0)
            {
                TempData["PostType"] = isStory ? "stories" : "posts";
                return RedirectToAction("PostNotFound");
            }

            return View(posts);
        }

        public IActionResult PostNotFound()
        {
            return View();
        }

        public IActionResult Details(string id, int userId)
        {
            var user = _postService.GetPostById(id);

            if (user == null)
            {
                return NotFound();
            }


            View view = new View
            {
                UserId = userId,
                PostId = id,
            };

            _viewService.AddView(view);

            return View(user);
        }
    }
}
