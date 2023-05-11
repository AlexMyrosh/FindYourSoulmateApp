using AutoMapper;
using BLL.Models;
using BLL.Services.Interfaces;
using DAL.Models;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class ChatService : IChatService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task AddMessageAsync(ChatMessageModel model)
        {
            var entity = _mapper.Map<ChatMessage>(model);
            entity.Timestamp = DateTime.Now;
            await _unitOfWork.ChatRepository.AddMessageAsync(entity);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<List<ChatMessageModel>> GetMessagesWithDetailsAsync(string currentUserId, string receiverUserId)
        {
            var entities = await _unitOfWork.ChatRepository.GetMessagesWithDetailsAsync(currentUserId, receiverUserId);
            var models = _mapper.Map<List<ChatMessageModel>>(entities);
            return models;
        }
    }
}
