namespace DAL.Models
{
    public class Contact
    {
        public Guid Id { get; set; }

        public User User { get; set; }

        public User ContactUser { get; set; }
    }
}
