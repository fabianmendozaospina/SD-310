using Instagram.Models;
using Microsoft.EntityFrameworkCore;

namespace Instagram.DAL
{
    public class ViewRepository
    {
        private readonly InstagramContext _context;

        public ViewRepository(InstagramContext context)
        {
            _context = context;
        }

        public List<View> GetAllViews()
        {
            return _context.Views.ToList();
        }

        public void AddView(View view)
        {
            View current = _context.Views.FirstOrDefault(v => v.UserId == view.UserId && v.PostId == view.PostId);

            if (current == null)
            {
                try
                {
                    view.ViewId = 0;
                    view.Timestamp = DateTime.Now;
                    _context.Views.Add(view);
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
