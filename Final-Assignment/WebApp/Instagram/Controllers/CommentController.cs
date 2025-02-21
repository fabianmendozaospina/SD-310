using Instagram.BLL;
using Instagram.Models;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class CommentController : Controller
    {
        private readonly CommentService _commentService;

        public CommentController(CommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddComment(int userId, string postId, string commentText)
        {
            if (ModelState.IsValid)
            {
                Comment comment = new Comment
                {
                    UserId = userId,
                    PostId = postId,
                    CommentText = commentText
                };

                try
                {
                    _commentService.AddComment(comment);
                    TempData["Status"] = "Comment add successfully!";
                }
                catch (Exception ex)
                {
                    TempData["Status"] = ex.Message;
                }
            }

            return RedirectToAction("Details", "Post", new { id = postId });
        }
    }
}
