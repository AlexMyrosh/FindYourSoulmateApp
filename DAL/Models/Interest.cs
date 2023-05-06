namespace DAL.Models
{
    public class Interest
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public List<User>? Users { get; set; }

        public bool IsDeleted { get; set; }
    }
}
