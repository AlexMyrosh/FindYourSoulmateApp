using BLL.Models;

namespace PL.ViewModels
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }

        public UserViewModel User { get; set; }

        public UserViewModel ContactUser { get; set; }
    }
}
