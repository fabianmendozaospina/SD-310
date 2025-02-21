using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class MessageService
    {
        private readonly MessageRepository _MessageRepository;

        public MessageService(MessageRepository MessageRepository)
        {
            _MessageRepository = MessageRepository;
        }

        public List<Message> GetMessages()
        {
            return _MessageRepository.GetAllMessages();
        }

        public void Send(Message Message)
        {
            _MessageRepository.Send(Message);
        }

    }
}
