using Instagram.BLL;
using Instagram.Models;
using Instagram.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Instagram.Controllers
{
    public class MessageController : Controller
    {
        private readonly MessageService _messageService;
        private readonly UserService _userService;

        public MessageController(MessageService messageService, UserService userService)
        {
            _messageService = messageService;
            _userService = userService;
        }

        public IActionResult Index()
        {
            MessageUsersViewModel messageUsers = new MessageUsersViewModel(_userService);
            return View(messageUsers);
        }

        [HttpPost]
        public IActionResult Send(Message message)
        {
            if (message.MessageText == null || message.MessageText.Trim() == string.Empty)
            {
                TempData["Status"] = "Enter your message!";

            }
            else
            {
                _messageService.Send(message);
                TempData["Status"] = "Message sent successfully!";
            }

            MessageUsersViewModel messageUsers = new MessageUsersViewModel(_userService);

            return RedirectToAction("Index");
        }
    }
}
