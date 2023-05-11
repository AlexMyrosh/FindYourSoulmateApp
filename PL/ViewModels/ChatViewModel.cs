namespace PL.ViewModels
{
    public class ChatViewModel
    {
        public ChatMessageViewModel ChatMessage { get; set; }

        public List<ChatMessageViewModel> MessageHistory { get; set; }

        public string CurrentUserId { get; set; }
    }
}
