namespace BLL.Models
{
    public class ChatMessageModel
    {
        public int Id { get; set; }

        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public UserModel Sender { get; set; }

        public UserModel Receiver { get; set; }
    }
}
