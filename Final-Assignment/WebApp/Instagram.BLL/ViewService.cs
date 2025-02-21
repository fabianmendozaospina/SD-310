using Instagram.DAL;
using Instagram.Models;

namespace Instagram.BLL
{
    public class ViewService
    {
        private readonly ViewRepository _ViewRepository;

        public ViewService(ViewRepository ViewRepository)
        {
            _ViewRepository = ViewRepository;
        }

        public List<View> GetViews()
        {
            return _ViewRepository.GetAllViews();
        }

        public void AddView(View View)
        {
            _ViewRepository.AddView(View);
        }

    }
}
