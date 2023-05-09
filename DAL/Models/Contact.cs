namespace DAL.Models
{
    public class Contact
    {
        public int Id { get; set; }

        public User ContactUser { get; set; }
    }
}
