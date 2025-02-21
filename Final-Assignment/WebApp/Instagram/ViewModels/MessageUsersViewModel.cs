using Instagram.BLL;
using Instagram.Models;

namespace Instagram.ViewModels
{
    public class MessageUsersViewModel
    {
        private readonly UserService _userService;
        public Message Message {  get; set; }
        public List<User> UsersList { get; set; } = new List<User>();

        public MessageUsersViewModel(UserService userService) {
            _userService = userService;
            UsersList = _userService.GetUsers();
        }
    }
}
