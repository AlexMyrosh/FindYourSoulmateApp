namespace BLL.Models
{
    public class ContactModel
    {
        public Guid Id { get; set; }

        public UserModel User { get; set; }

        public UserModel ContactUser { get; set; }
    }
}
