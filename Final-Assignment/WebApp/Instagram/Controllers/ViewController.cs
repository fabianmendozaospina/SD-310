using Instagram.BLL;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class ViewController : Controller
    {
        private readonly ViewService _viewService;

        public ViewController(ViewService viewService)
        {
            _viewService = viewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddView(int userId, string postId)
        {
                if (ModelState.IsValid)
                {
                    View View = new View
                    {
                        UserId = userId,
                        PostId = postId,
                    };

                    _viewService.AddView(View);
                }

                return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
