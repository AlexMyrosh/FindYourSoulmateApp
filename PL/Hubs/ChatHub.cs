using BLL.Services.Interfaces;
using DAL.Context;

using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace PL.Hubs
{
    public class ChatHub : Hub
    {
        private MssqlContext _context;
        private IUserService _userService;

        public ChatHub(MssqlContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task SendPrivateMessage(string userId, string message)
        {
            await _context.ChatMessages.AddAsync(new DAL.Models.ChatMessage
            {
                SenderId = "8088893b-0875-4040-90bb-f7c3f3bf52ac",
                ReceiverId = "4f48f6db-ef64-4531-be20-82fe7dab2e55",
                Content = message
            });
            await _context.SaveChangesAsync();
            userId = "4f48f6db-ef64-4531-be20-82fe7dab2e55";

            await Clients.User(userId).SendAsync("ReceiveMessage", "8088893b-0875-4040-90bb-f7c3f3bf52ac", message);
        }

        public async Task GetHistory(string otherUserId)
        {
            var currentUserId = "8088893b-0875-4040-90bb-f7c3f3bf52ac";
            otherUserId = "4f48f6db-ef64-4531-be20-82fe7dab2e55";

            var messages = await _context.ChatMessages
                .Where(m => (m.SenderId == currentUserId && m.ReceiverId == otherUserId)
                            || (m.ReceiverId == currentUserId && m.SenderId == otherUserId))
                .OrderBy(m => m.Timestamp)
                .Select(m => new { m.SenderId, m.Content })
                .ToListAsync();

            await Clients.Caller.SendAsync("ReceiveChatHistory", messages);
        }
    }
}
