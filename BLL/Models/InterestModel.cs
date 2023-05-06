namespace BLL.Models
{
    public class InterestModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<UserModel> Users { get; set; }
    }
}
