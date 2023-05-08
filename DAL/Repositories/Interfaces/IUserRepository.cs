using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace DAL.Repositories.Interfaces
{
    public interface IUserRepository
    {
        public Task<IdentityResult> AddAsync(User entity, string password);

        public User UpdateAsync(User entity);

        public Task<IdentityResult> ChangeEmailAsync(User user, string newEmail);

        public Task<IdentityResult> ChangeUsernameAsync(User user, string newUsername);

        public Task<IdentityResult> DeletePermanentlyAsync(User entity);

        public Task<IdentityResult> DeleteTemporarilyAsync(User entity);

        public Task<List<User>> GetAllAsync(bool includeDeleted = false);

        public Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false);

        public Task<User?> GetByIdAsync(string id);

        public Task<User?> GetByIdWithDetailsAsync(string id);
        
        public Task<User?> GetByEmailAsync(string email);

        public Task<User?> GetByEmailWithDetailsAsync(string email);

        public Task<User?> GetByUsernameAsync(string username);

        public Task<User?> GetByUsernameWithDetailsAsync(string username);

        public Task<User?> GetByPhoneNumberAsync(string phoneNumber);

        public Task<User?> GetByPhoneNumberWithDetailsAsync(string phoneNumber);

        public Task<User?> GetCurrentUserWithDetailsAsync(ClaimsPrincipal principal);

        public Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword);
    }
}