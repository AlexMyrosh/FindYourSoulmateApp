namespace DAL.Models
{
    public class Feedback
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Message { get; set; }

        public DateTime TimeOfCreation { get; set; }
    }
}
