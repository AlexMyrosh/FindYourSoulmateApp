using BLL.Models;

namespace BLL.Services.Interfaces
{
    public interface IChatService
    {
        public Task<List<ChatMessageModel>> GetMessagesWithDetailsAsync(string currentUserId, string receiverUserId);

        public Task AddMessageAsync(ChatMessageModel model);
    }
}
