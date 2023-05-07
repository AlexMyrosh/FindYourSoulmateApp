using BLL.Models;
using Microsoft.AspNetCore.Identity;

namespace BLL.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IdentityResult> AddAsync(UserModel model, string password);

        public Task<IdentityResult> UpdateAsync(UserModel model);

        public Task<IdentityResult> DeletePermanentlyAsync(UserModel model);

        public Task<IdentityResult> DeleteTemporarilyAsync(UserModel model);

        public Task<List<UserModel>> GetAllAsync(bool includeDeleted = false);

        public Task<List<UserModel>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<UserModel?> GetByIdAsync(Guid id);

        public Task<UserModel?> GetByIdWithDetailsAsync(Guid id);

        public Task<UserModel?> GetByEmailAsync(string email);

        public Task<UserModel?> GetByEmailWithDetailsAsync(string email);

        public Task<UserModel?> GetByUsernameAsync(string username);

        public Task<UserModel?> GetByUsernameWithDetailsAsync(string username);

        public Task<UserModel?> GetByPhoneNumberAsync(string phoneNumber);

        public Task<UserModel?> GetByPhoneNumberWithDetailsAsync(string phoneNumber);
    }
}