using System.Security.Claims;
using AutoMapper;
using BLL.Services.Interfaces;
using DAL.Models;
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

        public async Task LikeUser(ClaimsPrincipal principal, string likedUserId)
        {
            var currentUser = await _unitOfWork.UserRepository.GetCurrentUserWithDetailsAsync(principal);

            if (currentUser == null)
            {
                throw new ArgumentException(nameof(currentUser));
            }

            var likedUser = await _unitOfWork.UserRepository.GetByIdWithDetailsAsync(likedUserId);

            if (likedUser == null)
            {
                throw new InvalidOperationException(nameof(likedUser));
            }

            if (IsMutualLike(currentUser.Id, likedUser))
            {
                await _unitOfWork.ContactRepository.AddAsync(new Contact
                {
                    User = currentUser,
                    ContactUser = likedUser
                });
            }

            currentUser.LikedUsers.Add(likedUser);
            _unitOfWork.UserRepository.UpdateAsync(currentUser);
            await _unitOfWork.SaveChangesAsync();
        }

        private bool IsMutualLike(string currentUserId, User likedUser)
        {
            return likedUser.LikedUsers.Select(u => u.Id).Contains(currentUserId);
        }
    }
}
