using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.DAL
{
    public class MessageRepository
    {
        private readonly InstagramContext _context;

        public MessageRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<Message> GetAllMessages()
        {
            return _context.Messages.ToList();
        }

        public void Send(Message message)
        {
            Message current = _context.Messages.FirstOrDefault(v => v.SenderId == message.SenderId && v.ReceiverId == message.ReceiverId && v.MessageText == message.MessageText);

            if (current == null)
            {
                try
                {
                    message.MessageId = 0;
                    message.Timestamp = DateTime.Now;
                    _context.Messages.Add(message);
                    _context.SaveChanges();
                }
                catch (DbUpdateException ex)
                {
                    Console.WriteLine($"Error: {ex.InnerException?.Message}");
                }
            }


        }
    }
}
