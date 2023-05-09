using BLL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> AddAsync(UserModel model, string password);

        public Task<UserModel> UpdateAsync(UserModel model);

        public Task UpdateEmail(ClaimsPrincipal principal, string newEmail);

        public Task UpdateUsername(ClaimsPrincipal principal, string newUsername);

        public Task<IdentityResult> DeletePermanentlyAsync(UserModel model);

        public Task<IdentityResult> DeleteTemporarilyAsync(UserModel model);

        public Task<List<UserModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<UserModel>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<UserModel?> GetByIdAsync(string id);

        public Task<UserModel?> GetByIdWithDetailsAsync(string id);

        public Task<UserModel?> GetByEmailAsync(string email);

        public Task<UserModel?> GetByEmailWithDetailsAsync(string email);

        public Task<UserModel?> GetByUsernameAsync(string username);

        public Task<UserModel?> GetByUsernameWithDetailsAsync(string username);

        public Task<UserModel?> GetByPhoneNumberAsync(string phoneNumber);

        public Task<UserModel?> GetByPhoneNumberWithDetailsAsync(string phoneNumber);

        public Task<UserModel?> GetCurrentUserWithDetailsAsync(ClaimsPrincipal principal);

        public Task<IdentityResult> ChangePasswordAsync(UserModel user, string currentPassword, string newPassword);

        public Task<List<UserModel>> GetOtherUsersWithDetailsAsync(string currentUserId);

        public Task<List<UserModel>> GetUsersToShow(ClaimsPrincipal principal);
    }
}