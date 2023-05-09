using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly MssqlContext _sqlContext;

        public ChatRepository(MssqlContext sqlContext)
        {
            _sqlContext = sqlContext;
        }

        public async Task AddMessageAsync(ChatMessage entity)
        {
            await _sqlContext.ChatMessages.AddAsync(entity);
        }

        public async Task<List<ChatMessage>> GetMessagesWithDetailsAsync(string currentUserId, string receiverUserId)
        {
            var messages = await _sqlContext.ChatMessages
                .Where(m => (m.SenderId == currentUserId && m.ReceiverId == receiverUserId) || (m.SenderId == receiverUserId && m.ReceiverId == currentUserId))
                .Include(m => m.Sender)
                .Include(m => m.Receiver)
                .ToListAsync();

            return messages;
        }
    }
}
