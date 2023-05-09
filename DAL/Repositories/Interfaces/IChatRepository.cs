using DAL.Models;

namespace DAL.Repositories.Interfaces
{
    public interface IChatRepository
    {
        public Task<List<ChatMessage>> GetMessagesWithDetailsAsync(string currentUserId, string receiverUserId);

        public Task AddMessageAsync(ChatMessage entity);
    }
}
