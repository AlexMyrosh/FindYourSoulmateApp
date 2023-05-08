using AutoMapper;
using BLL.Services.Interfaces;
using DAL.UnitOfWork;

namespace BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ProfileService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task LikeUser(string currentUserId, string likedUserId)
        {
            var currentUser = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(currentUserId);
            currentUser.LikedUsers.Add(await _unitOfWork.UserRepository.GetByIdAsync(likedUserId));
            _unitOfWork.UserRepository.UpdateAsync(currentUser);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
