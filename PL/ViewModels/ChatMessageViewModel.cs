namespace PL.ViewModels
{
    public class ChatMessageViewModel
    {
        public string SenderId { get; set; }

        public string ReceiverId { get; set; }

        public string Content { get; set; }

        public DateTime Timestamp { get; set; }

        public UserViewModel Sender { get; set; }

    }
}
