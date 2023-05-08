using System.Security.Claims;
using DAL.Context;
using DAL.Models;
using DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly UserManager<User> _userManager;
        private readonly MssqlContext _context;

        public UserRepository(UserManager<User> userManager, MssqlContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<IdentityResult> AddAsync(User entity, string password)
        {
            return await _userManager.CreateAsync(entity, password);
        }

        public User UpdateAsync(User entity)
        {
            return _context.Users.Update(entity).Entity;
        }

        public async Task<IdentityResult> ChangeEmailAsync(User user, string newEmail)
        {
            var token = await _userManager.GenerateChangeEmailTokenAsync(user, newEmail);
            return await _userManager.ChangeEmailAsync(user, newEmail, token);
        }

        public async Task<IdentityResult> ChangeUsernameAsync(User user, string newUsername)
        {
            return await _userManager.SetUserNameAsync(user, newUsername);
        }

        public async Task<IdentityResult> DeletePermanentlyAsync(User entity)
        {
            return await _userManager.DeleteAsync(entity);
        }

        public async Task<IdentityResult> DeleteTemporarilyAsync(User entity)
        {
            entity.IsDeleted = true;
            return await _userManager.UpdateAsync(entity);
        }

        public async Task<List<User>> GetAllAsync(bool includeDeleted = false)
        {
            return await _userManager.Users
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<List<User>> GetAllWithDetailsAsync(bool includeDeleted = false)
        {
            return await _userManager.Users
                .Include(entity=> entity.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Include(entity => entity.Interests)
                .Where(entity => entity.IsDeleted == false || entity.IsDeleted == includeDeleted)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<User?> GetByIdWithDetailsAsync(string id)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Include(entity => entity.LikedUsers)
                .Include(entity => entity.LikedByUsers)
                .Where(entity => entity.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailAsync(string email)
        {
            return await _userManager.Users
                .Where(entity => entity.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByEmailWithDetailsAsync(string email)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(entity => entity.Email == email)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameAsync(string username)
        {
            return await _userManager.Users
                .Where(entity => entity.UserName == username)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByUsernameWithDetailsAsync(string username)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(entity => entity.UserName == username)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByPhoneNumberAsync(string phoneNumber)
        {
            return await _userManager.Users
                .Where(entity => entity.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetByPhoneNumberWithDetailsAsync(string phoneNumber)
        {
            return await _userManager.Users
                .Include(entity => entity.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(entity => entity.PhoneNumber == phoneNumber)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> GetCurrentUserWithDetailsAsync(ClaimsPrincipal principal)
        {
            var id = _userManager.GetUserId(principal);
            var result = await _userManager.Users
                .Include(u => u.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();

            return result;
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<List<User>> GetOtherUsersWithDetailsAsync(string currentUserId)
        {
            return await _userManager.Users
                .Include(u => u.Interests)
                .Include(entity => entity.LikedByUsers)
                .Include(entity => entity.LikedUsers)
                .Where(user => user.Id != currentUserId)
                .ToListAsync();
        }
    }
}
